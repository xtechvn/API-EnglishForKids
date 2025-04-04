﻿using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class TourPackagesOptional
{
    public long Id { get; set; }

    public long? TourId { get; set; }

    public int? SupplierId { get; set; }

    public string? PackageName { get; set; }

    public int? Packageid { get; set; }

    public double? Amount { get; set; }

    public int? Quantity { get; set; }

    public int? Times { get; set; }

    public double? Price { get; set; }

    public string? Note { get; set; }

    public int? Status { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
