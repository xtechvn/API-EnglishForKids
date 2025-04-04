﻿using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class TourDestination
{
    public long Id { get; set; }

    public long? TourId { get; set; }

    public int? LocationId { get; set; }

    /// <summary>
    /// Lưu theo Tour Type 
    /// </summary>
    public int? Type { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
