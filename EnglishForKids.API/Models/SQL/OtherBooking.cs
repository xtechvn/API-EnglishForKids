﻿using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class OtherBooking
{
    public long Id { get; set; }

    public long OrderId { get; set; }

    public int ServiceType { get; set; }

    public int Status { get; set; }

    public string ServiceCode { get; set; } = null!;

    public double Amount { get; set; }

    public double Profit { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public double? Price { get; set; }

    public int? SupplierId { get; set; }

    public string? Note { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? OperatorId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? StatusOld { get; set; }

    public double? Commission { get; set; }

    public double? OthersAmount { get; set; }

    public string? ConfNo { get; set; }

    public string? SerialNo { get; set; }

    public string? RoomNo { get; set; }
}
