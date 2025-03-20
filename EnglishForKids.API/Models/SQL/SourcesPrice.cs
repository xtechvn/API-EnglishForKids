using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class SourcesPrice
{
    public int Id { get; set; }

    public int SourceId { get; set; }

    public double? Price { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public short? Status { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? UpdatedBy { get; set; }
}
