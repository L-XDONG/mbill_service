﻿using System.Collections.Generic;

namespace mbill.Service.Bill.Category;

public class CategorySvc : ApplicationSvc, ICategorySvc
{
    private readonly ICategoryRepo _categoryRepo;
    private readonly IFileRepo _fileRepo;

    public CategorySvc(ICategoryRepo categoryRepo, IFileRepo fileRepo)
    {
        _categoryRepo = categoryRepo;
        _fileRepo = fileRepo;
    }

    public async Task<ServiceResult<CategoryDto>> InsertAsync(CreateCategoryInput input)
    {
        var categroy = Mapper.Map<CategoryEntity>(input);
        bool isRepeatName = await _categoryRepo.Select.AnyAsync(r => r.Name == categroy.Name && CurrentUser.Id == r.CreateUserId);
        if (isRepeatName)//分类名重复
            return ServiceResult<CategoryDto>.Failed("分类名称重复，请重新输入");

        var entity = await _categoryRepo.InsertAsync(categroy);
        return ServiceResult<CategoryDto>.Successed(Mapper.Map<CategoryDto>(entity));
    }

    public async Task<ServiceResult> DeleteAsync(long id)
    {
        var category = await _categoryRepo.Select.Where(s => s.Id == id && s.CreateUserId == CurrentUser.Id).ToOneAsync();
        if (category == null) return ServiceResult.Failed(ServiceResultCode.NotFound, "没有找到该账单分类信息");
        var cnt = await _categoryRepo.DeleteAsync(id);
        // 如果是分组，则删除分类
        if (cnt > 0 && category.ParentId == 0)
            await _categoryRepo.DeleteAsync(c => c.ParentId == id);
        return ServiceResult.Successed();
    }

    public async Task<ServiceResult<CategoryDto>> EditAsync(EditCategoryInput input)
    {
        var category = await _categoryRepo.Select.Where(s => s.Id == input.Id && !s.IsDeleted).ToOneAsync();
        if (category == null) return ServiceResult<CategoryDto>.Failed(ServiceResultCode.NotFound, "没有找到该账单分类信息");
        category.Name = input.Name;
        category.Budget = input.Budget;
        category.Icon = input.Icon;
        await _categoryRepo.UpdateAsync(category);
        return ServiceResult<CategoryDto>.Successed(Mapper.Map<CategoryDto>(category));
    }

    public async Task<ServiceResult<CategoryDto>> GetAsync(long id)
    {
        var category = await _categoryRepo.GetCategoryAsync(id);
        if (category == null)
            return ServiceResult<CategoryDto>.Failed(ServiceResultCode.NotFound, "分类信息不存在或已删除！");
        return ServiceResult<CategoryDto>.Successed(Mapper.Map<CategoryDto>(category));
    }

    public async Task<ServiceResult<List<CategoryDto>>> GetsAsync(int type)
    {
        var categories = await _categoryRepo.Select.Where(c => c.ParentId != 0 && c.Type == type && c.CreateUserId == CurrentUser.Id).ToListAsync();
        var dtos = categories.Select(c => Mapper.Map<CategoryDto>(c)).ToList();
        return ServiceResult<List<CategoryDto>>.Successed(dtos);
    }

    public async Task<ServiceResult<CategoryDto>> GetParentAsync(long id)
    {
        var category = await _categoryRepo.GetCategoryAsync(id);
        if (category == null)
            return ServiceResult<CategoryDto>.Failed(ServiceResultCode.NotFound, "分类信息不存在或已删除！");
        var categoryParent = await _categoryRepo.GetCategoryAsync(category.ParentId);
        if (categoryParent == null)
            return ServiceResult<CategoryDto>.Failed(ServiceResultCode.NotFound, "分类父项信息不存在或已删除！");
        return ServiceResult<CategoryDto>.Successed(Mapper.Map<CategoryDto>(categoryParent));
    }

    public async Task<ServiceResult<IEnumerable<CategoryDto>>> GetParentsAsync()
    {
        var assets = await _categoryRepo
            .Select
            .Where(a => a.ParentId == 0)
            .OrderBy(a => a.CreateTime)
            .ToListAsync();
        var categoryDtos = assets.Select(a => Mapper.Map<CategoryDto>(a)).ToList();
        return ServiceResult<IEnumerable<CategoryDto>>.Successed(categoryDtos);
    }

    public async Task<ServiceResult<IEnumerable<CategoryGroupDto>>> GetGroupsAsync(int? type)
    {
        List<CategoryEntity> entities = await _categoryRepo
            .Select
            .Where(c => c.CreateUserId == CurrentUser.Id)
            .WhereIf(type.HasValue, c => c.Type == type)
            .ToListAsync();
        List<CategoryEntity> parents = entities.FindAll(c => c.ParentId == 0).OrderByDescending(d => d.Sort).ToList();
        List<CategoryGroupDto> dtos = parents
            .Select(c =>
            {
                var dto = new CategoryGroupDto();
                dto.Id = c.Id;
                dto.Name = c.Name;
                dto.Childs = entities
                    .FindAll(d => d.ParentId == c.Id)
                    .Select(d =>
                    {
                        return Mapper.Map<CategoryDto>(d);
                    }).OrderByDescending(d => d.Sort)
                    .ToList();
                return dto;
            })
            .ToList();
        return ServiceResult<IEnumerable<CategoryGroupDto>>.Successed(dtos);
    }

    public async Task<ServiceResult<PagedDto<CategoryPageDto>>> GetPageAsync(CategoryPagingInput pagingDto)
    {
        if (pagingDto.CreateStartTime != null && pagingDto.CreateEndTime == null) throw new KnownException("创建时间参数有误", ServiceResultCode.ParameterError);
        var parentIds = new List<string>();
        if (!string.IsNullOrWhiteSpace(pagingDto.ParentIds))
            parentIds = pagingDto.ParentIds.Split(",").ToList();
        pagingDto.Sort = pagingDto.Sort.IsNullOrEmpty() ? "id ASC" : pagingDto.Sort.Replace("-", " ");
        var categories = await _categoryRepo
            .Select
            .WhereIf(!string.IsNullOrWhiteSpace(pagingDto.CategoryName), c => c.Name.Contains(pagingDto.CategoryName))
            .WhereIf(parentIds != null && parentIds.Any(), c => parentIds.Contains(c.ParentId.ToString()))
            .WhereIf(!string.IsNullOrWhiteSpace(pagingDto.Type), c => c.Type.Equals(pagingDto.Type))
            .WhereIf(pagingDto.CreateStartTime != null, c => c.CreateTime >= pagingDto.CreateStartTime && c.CreateTime <= pagingDto.CreateEndTime)
            .OrderBy(pagingDto.Sort)
            .ToPageListAsync(pagingDto, out long totalCount);
        var categoryDtos = categories.Select(c =>
        {
            var dto = Mapper.Map<CategoryPageDto>(c);
            CategoryEntity category = null;
            if (c.ParentId != 0)
                category = _categoryRepo.Get(c.ParentId);
            dto.ParentName = category?.Name;
            dto.TypeName = SystemConst.Switcher.CategoryType(c.Type);
            dto.IconUrl = _fileRepo.GetFileUrl(c.Icon);
            return dto;
        }).ToList();

        return ServiceResult<PagedDto<CategoryPageDto>>.Successed(new PagedDto<CategoryPageDto>(categoryDtos, totalCount));
    }

    public async Task<ServiceResult> SortAsync(SortCategoryInput input)
    {
        var edits = input.Sorts.Select(s => new CategoryEntity { Id = s.Id, Sort = s.Sort }).ToList();
        var cnt = await _categoryRepo.Orm.Update<CategoryEntity>().SetSource(edits).UpdateColumns(e => new { e.Sort }).ExecuteAffrowsAsync();
        if (cnt <= 0) return ServiceResult.Failed("排序失败");
        return ServiceResult.Successed();
    }
}
