﻿using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class VinWonderBooking
{
    public long Id { get; set; }

    public string? SiteName { get; set; }

    public string? SiteCode { get; set; }

    public double? TotalPrice { get; set; }

    public int? Status { get; set; }

    public double? Amount { get; set; }

    public double? TotalProfit { get; set; }

    public int? SupplierId { get; set; }

    public long? OrderId { get; set; }

    public int? SalerId { get; set; }

    public string? Note { get; set; }

    public double? TotalUnitPrice { get; set; }

    public string? AdavigoBookingId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? ServiceCode { get; set; }

    public int? StatusOld { get; set; }

    public double? Commission { get; set; }

    public double? OthersAmount { get; set; }
}
