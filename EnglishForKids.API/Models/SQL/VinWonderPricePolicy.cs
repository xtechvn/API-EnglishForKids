﻿using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class VinWonderPricePolicy
{
    public int Id { get; set; }

    public int CampaignId { get; set; }

    /// <summary>
    /// Khóa chính của các loại vé theo tên đặt bên Vinwonder
    /// </summary>
    public int ServiceId { get; set; }

    public double BasePrice { get; set; }

    public double WeekendRate { get; set; }

    public double Profit { get; set; }

    public short UnitType { get; set; }

    public int RateCode { get; set; }

    public string ServiceCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public double AmountBase { get; set; }

    public double AmountWeekend { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? SiteId { get; set; }

    public string? SiteName { get; set; }

    public virtual Campaign Campaign { get; set; } = null!;
}
