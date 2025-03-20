using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class Airline
{
    public string Code { get; set; } = null!;

    public string NameVi { get; set; } = null!;

    public string NameEn { get; set; } = null!;

    public string AirLineGroup { get; set; } = null!;

    public string? Logo { get; set; }

    public int? SupplierId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
