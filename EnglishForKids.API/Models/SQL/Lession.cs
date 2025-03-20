using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class Lession
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Author { get; set; }

    public string? VideoDuration { get; set; }

    public string? Thumbnail { get; set; }

    public int? View { get; set; }

    public int? ChapterId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? ThumbnailName { get; set; }

    public int IsDelete { get; set; }

    public string? Article { get; set; }
}
