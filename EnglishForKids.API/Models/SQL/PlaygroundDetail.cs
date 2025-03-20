﻿using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class PlaygroundDetail
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public int ServiceType { get; set; }

    /// <summary>
    /// Bài viết liên quan
    /// </summary>
    public int NewsId { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateTime { get; set; }

    public string? LocationName { get; set; }

    public int? Status { get; set; }

    public string? Description { get; set; }
}
