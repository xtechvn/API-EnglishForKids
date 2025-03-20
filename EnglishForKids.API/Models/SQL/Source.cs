using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class Source
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Thumbnail { get; set; }

    public int? Status { get; set; }

    public string? Benefif { get; set; }

    public decimal? Price { get; set; }

    public int? SubTopicId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? AuthorId { get; set; }

    public decimal? OriginalPrice { get; set; }

    public int? Type { get; set; }

    public DateTime? DownTime { get; set; }

    public int? Position { get; set; }

    public DateTime? PublishDate { get; set; }

    public string? VideoIntro { get; set; }
}
