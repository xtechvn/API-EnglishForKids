using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class AffiliateGroupProduct
{
    public int Id { get; set; }

    public int GroupProductId { get; set; }

    public int AffType { get; set; }
}
