using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class Discount
{
    public int Id { get; set; }

    public double? PriceDiscount { get; set; }

    public int? SourceId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
