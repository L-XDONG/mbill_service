﻿namespace mbill.Service.Bill.Bill.Output;

public class BillGroupByDayDto
{
    public int Day { get; set; }

    public string Week { get; set; }

    public List<BillSimpleDto> Items { get; set; } = new List<BillSimpleDto>();
}
