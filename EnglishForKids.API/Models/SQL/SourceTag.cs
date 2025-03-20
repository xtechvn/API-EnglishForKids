using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class SourceTag
{
    public int Id { get; set; }

    public long? TagId { get; set; }

    public int SourceId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? Updatedby { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
