﻿using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class TourPosition
{
    public long Id { get; set; }

    public int? TourId { get; set; }

    /// <summary>
    /// 1: B2C , 2: B2B
    /// </summary>
    public short? PositionType { get; set; }

    public int? Position { get; set; }

    public int? Status { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
