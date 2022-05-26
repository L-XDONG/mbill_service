﻿using mbill.Service.Bill.Bill.Input;

namespace mbill.Controllers.Bill;

/// <summary>
/// 账单管理
/// </summary>
[Authorize]
[Route("api/bill")]
[ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
public class BillController : ApiControllerBase
{
    private readonly IMapper _mapper;
    private readonly IBillSvc _billSvc;

    public BillController(IBillSvc billService, IMapper mapper)
    {
        _mapper = mapper;
        _billSvc = billService;
    }

    /// <summary>
    /// 新增账单
    /// </summary>
    /// <param name="dto">账单</param>
    [Logger("用户新建了一条账单记录")]
    [HttpPost]
    [LocalAuthorize("新增", "账单")]
    public async Task<ServiceResult<BillDto>> CreateAsync([FromBody] ModifyBillInput dto)
    {
        var result = await _billSvc.InsertAsync(_mapper.Map<BillEntity>(dto));
        return ServiceResult<BillDto>.Successed(result, "账单分类创建成功！");
    }

    /// <summary>
    /// 获取账单详情
    /// </summary>
    /// <param name="id">账单id</param>
    [HttpGet("detail")]
    [LocalAuthorize("获取详情", "账单")]
    [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
    public async Task<ServiceResult<BillDetailDto>> GetAsync([FromQuery] long id)
    {
        return ServiceResult<BillDetailDto>.Successed(await _billSvc.GetDetailAsync(id));
    }

    /// <summary> 
    /// 删除账单信息
    /// </summary>
    /// <param name="id">账单id</param>
    [HttpDelete]
    [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
    public async Task<ServiceResult> DeleteAsync([FromQuery] long id)
    {
        await _billSvc.DeleteAsync(id);
        return ServiceResult.Successed("账单删除成功！");
    }

    /// <summary>
    /// 更新账单信息
    /// </summary>
    /// <param name="dto">账单信息</param>
    [HttpPut]
    [LocalAuthorize("更新", "账单")]
    [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
    public async Task<ServiceResult> UpdateAsync([FromBody] ModifyBillInput dto)
    {
        await _billSvc.UpdateAsync(_mapper.Map<BillEntity>(dto));
        return ServiceResult.Successed("账单更新成功！");
    }

    /// <summary>
    /// 获取指定月份日分组分页账单
    /// </summary>
    /// <param name="input">分页条件</param>
    [HttpGet("month/pages")]
    [LocalAuthorize("获取指定月份日分组分页账单", "账单")]
    [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
    public async Task<ServiceResult<PagedDto<BillGroupByDayDto>>> GetMonthPagesAsync([FromQuery] MonthBillPagingInput input)
    {
        return ServiceResult<PagedDto<BillGroupByDayDto>>.Successed(await _billSvc.GetMonthPagesAsync(input));
    }


    /// <summary>
    /// 获取日期范围内存在账单的日期
    /// </summary>
    /// <param name="input">查询入参</param>
    [HttpGet("date/has-bill-days")]
    [LocalAuthorize("获取日期范围内存在账单的日期", "账单")]
    [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
    public async Task<ServiceResult<IEnumerable<BillDateWithTotalDto>>> RangeHasBillDaysAsync([FromQuery] RangeHasBillDaysInput input)
    {
        return ServiceResult<IEnumerable<BillDateWithTotalDto>>.Successed(await _billSvc.RangeHasBillDaysAsync(input));
    }

    /// <summary>
    /// 获取指定月份账单总金额
    /// </summary>
    /// <param name="input">入参</param>
    [HttpGet("stat/month-total")]
    [LocalAuthorize("获取指定月份账单总金额", "账单")]
    [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
    public async Task<ServiceResult<MonthTotalStatOutput>> GetMonthTotalStatAsync([FromQuery] MonthTotalStatInput input)
    {
        return ServiceResult<MonthTotalStatOutput>.Successed(await _billSvc.GetMonthTotalStatAsync(input));
    }

    /*/// <summary>
    /// 获取指定日期各类型账单金额统计
    /// </summary>
    /// <param name="input">入参</param>
    [HttpGet("statistics/total")]
    [LocalAuthorize("获取各类型金额统计", "账单")]
    [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
    public async Task<ServiceResult<BillTotalDto>> GetMonthStatisticsAsync([FromQuery] BillDateInput input)
    {
        return ServiceResult<BillTotalDto>.Successed(await _billService.GetStatisticsTotalAsync(input));
    }

    /// <summary>
    /// 获取指定日期支出分类统计
    /// </summary>
    /// <param name="input">查询入参</param>
    [HttpGet("statistics/expend/category")]
    [LocalAuthorize("获取日期内指定分类的数据", "账单")]
    [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
    public async Task<ServiceResult<BillExpendCategoryDto>> GetExpendCategoryStatisticsAsync([FromQuery] BillDateInput input)
    {
        return ServiceResult<BillExpendCategoryDto>.Successed(await _billService.GetExpendCategoryStatisticsAsync(input));
    }

    /// <summary>
    /// 获取当前月份所有周的支出趋势统计
    /// </summary>
    /// <param name="input">查询入参</param>
    [HttpGet("statistics/expend/trend/week")]
    [LocalAuthorize("获取周指定分类的趋势统计", "账单")]
    [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
    public async Task<ServiceResult<IEnumerable<BillExpendTrendDto>>> GetWeekExpendTrendStatisticsAsync([FromQuery] BillDateInput input)
    {
        return ServiceResult<IEnumerable<BillExpendTrendDto>>.Successed(await _billService.GetWeekExpendTrendStatisticsAsync(input));
    }

    /// <summary>
    /// 获取当前月往前4个月的支出趋势统计(共5个月)
    /// </summary>
    /// <param name="input">查询入参</param>
    [HttpGet("statistics/expend/trend/5month")]
    [LocalAuthorize("获取五个月指定分类的趋势统计", "账单")]
    [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
    public async Task<ServiceResult<IEnumerable<BillExpendTrendDto>>> GetMonthExpendTrendStatisticsAsync([FromQuery] BillDateInput input)
    {
        return ServiceResult<IEnumerable<BillExpendTrendDto>>.Successed(await _billService.GetMonthExpendTrendStatisticsAsync(input, 5));
    }*/

}
