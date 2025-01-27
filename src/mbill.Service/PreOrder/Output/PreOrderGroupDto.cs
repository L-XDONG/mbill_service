﻿namespace mbill.Service.PreOrder.Output;

public class PreOrderGroupDto : EntityDto
{
    public long BillId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Time { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
}
