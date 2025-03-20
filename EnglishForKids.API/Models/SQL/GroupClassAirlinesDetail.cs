using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class GroupClassAirlinesDetail
{
    public int Id { get; set; }

    public int GroupClassAirlinesId { get; set; }

    public string Name { get; set; } = null!;
}
