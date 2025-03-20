using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class FlyBookingExtraPackage
{
    public long Id { get; set; }

    public string PackageId { get; set; } = null!;

    public string PackageCode { get; set; } = null!;

    public string? GroupFlyBookingId { get; set; }

    public decimal Amount { get; set; }

    public decimal? BasePrice { get; set; }

    public int? Quantity { get; set; }

    public double? Price { get; set; }

    public double? Profit { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
