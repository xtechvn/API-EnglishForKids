using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class AirPortCode
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? DistrictEn { get; set; }

    public string? DistrictVi { get; set; }

    public int? CountryId { get; set; }
}
