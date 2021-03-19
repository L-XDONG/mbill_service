﻿using AutoMapper;
using Memoyu.Mbill.Application.Bill.Statement;
using Memoyu.Mbill.Application.Contracts.Attributes;
using Memoyu.Mbill.Application.Contracts.Dtos.Bill.Statement;
using Memoyu.Mbill.Domain.Entities.Bill.Statement;
using Memoyu.Mbill.Domain.Shared.Const;
using Memoyu.Mbill.ToolKits.Base;
using Memoyu.Mbill.ToolKits.Base.Page;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memoyu.Mbill.WebApi.Controllers.Bill
{
    /// <summary>
    /// 账单管理
    /// </summary>
    [Route("api/statement")]
    [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
    public class StatementController : ApiControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStatementService _statementService;

        public StatementController(IStatementService statementService,IMapper mapper)
        {
            _mapper = mapper;
            _statementService = statementService;
        }

        /// <summary>
        /// 新增账单
        /// </summary>
        /// <param name="dto">账单</param>
        [Logger("用户新建了一条账单记录")]
        [HttpPost("create")]
        [Authorize]
        public async Task<ServiceResult<StatementDto>> CreateAsync([FromBody] ModifyStatementDto dto)
        {
            var result = await _statementService.InsertAsync(_mapper.Map<StatementEntity>(dto));
            return ServiceResult<StatementDto>.Successed(result, "账单分类创建成功！");
        }

        /// <summary>
        /// 获取账单详情
        /// </summary>
        /// <param name="id">账单id</param>
        [HttpGet("detail")]
        [Authorize]
        [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
        public async Task<ServiceResult<StatementDetailDto>> GetAsync([FromQuery]long id)
        {
            return ServiceResult<StatementDetailDto>.Successed(await _statementService.GetDetailAsync(id));
        }

        /// <summary> 
        /// 删除账单信息
        /// </summary>
        /// <param name="id">账单id</param>
        [HttpDelete("delete")]
        [Authorize]
        [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
        public async Task<ServiceResult> DeleteAsync([FromQuery] long id)
        {
            await _statementService.DeleteAsync(id);
            return ServiceResult.Successed("账单删除成功！");
        }

        /// <summary>
        /// 更新账单信息
        /// </summary>
        /// <param name="dto">账单信息</param>
        [HttpPut("update")]
        [Authorize]
        [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
        public async Task<ServiceResult> UpdateAsync([FromBody] ModifyStatementDto dto)
        {
            await _statementService.UpdateAsync(_mapper.Map<StatementEntity>(dto));
            return ServiceResult.Successed("账单更新成功！");
        }

        /// <summary>
        /// 获取账单分页信息
        /// </summary>
        /// <param name="pagingDto">分页条件</param>
        [HttpGet("pages")]
        [Authorize]
        [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
        public async Task<ServiceResult<PagedDto<StatementDto>>> GetStatementPagesAsync([FromQuery] StatementPagingDto pagingDto)
        {
            return ServiceResult<PagedDto<StatementDto>>.Successed(await _statementService.GetPagesAsync(pagingDto));
        }

        /// <summary>
        /// 获取账单月各类型账单金额统计
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        [HttpGet("statistics/total")]
        [Authorize]
        [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
        public async Task<ServiceResult<StatementTotalDto>> GetMonthStatisticsAsync([FromQuery] StatementTotalInputDto input)
        {
            return ServiceResult<StatementTotalDto>.Successed(await _statementService.GetMonthStatisticsAsync(input));
        }

    }
}
