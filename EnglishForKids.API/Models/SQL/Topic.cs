using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class Topic
{
    public int Id { get; set; }

    public string? TopicName { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
