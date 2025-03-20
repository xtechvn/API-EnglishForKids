using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class GroupClassAirline
{
    public int Id { get; set; }

    public string Airline { get; set; } = null!;

    public string ClassCode { get; set; } = null!;

    public string FareType { get; set; } = null!;

    public string DetailVi { get; set; } = null!;

    public string DetailEn { get; set; } = null!;

    public string? Description { get; set; }
}
