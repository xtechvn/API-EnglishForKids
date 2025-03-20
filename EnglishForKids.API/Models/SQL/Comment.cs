using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class Comment
{
    public int Id { get; set; }

    public int RequestId { get; set; }

    public string? Content { get; set; }

    public string? AttachFile { get; set; }

    public DateTime? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? AttachFileName { get; set; }
}
