﻿namespace mbill.Service.Bill.Bill.Input;

public class ModifyBillInput
{
    public long? Id { get; set; }

    /// <summary>
    /// 分类Id
    /// </summary>
    public long CategoryId { get; set; }

    /// <summary>
    /// 资产Id
    /// </summary>
    [Required(ErrorMessage = "必须传入源资产Id")]
    public long AssetId { get; set; }

    /// <summary>
    /// 金额
    /// </summary>
    [Required(ErrorMessage = "金额不能为空")]
    [Range(0.01, 100000, ErrorMessage = "金额应该在0.01-100000之间")]
    public decimal Amount { get; set; }

    /// <summary>
    /// 记录类型：支出、收入、转账、还款
    /// </summary>
    [Required(ErrorMessage = "必须传入账单类型")]
    public int Type { get; set; }

    /// <summary>
    /// 说明
    /// </summary>
    [MaxLength(40, ErrorMessage = "描述长度不超过40")]
    public string Description { get; set; }

    /// <summary>
    /// 地点
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// 记录日期：时间
    /// </summary>
    [Required(ErrorMessage = "必须传入记录日期：时间")]
    public DateTime Time { get; set; }
}