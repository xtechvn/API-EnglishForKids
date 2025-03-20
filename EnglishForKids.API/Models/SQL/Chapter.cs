using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class Chapter
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? SourceId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int IsDelete { get; set; }
}
