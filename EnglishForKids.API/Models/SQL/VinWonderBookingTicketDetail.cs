﻿using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class VinWonderBookingTicketDetail
{
    public long Id { get; set; }

    public long? BookingTicketId { get; set; }

    public string? Code { get; set; }

    public string? ServiceKey { get; set; }

    public string? ShortName { get; set; }

    public string? Name { get; set; }

    public string? GroupName { get; set; }

    public string? TypeName { get; set; }

    public double? BasePrice { get; set; }

    public double? Price { get; set; }

    public double? TotalPrice { get; set; }

    public double? RateDiscountPercent { get; set; }

    public double? RateDiscountPrice { get; set; }

    public double? PromotionDiscountPercent { get; set; }

    public double? PromotionDiscountPrice { get; set; }

    public double? Vatpercent { get; set; }

    public int? Availability { get; set; }

    public int? NumberOfUses { get; set; }

    public DateTime? DateFrom { get; set; }

    public DateTime? DateTo { get; set; }

    public string? WeekDays { get; set; }

    public string? GateCode { get; set; }

    public string? GateName { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? TypeCode { get; set; }
}
