﻿using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class HotelBookingRoom
{
    public long Id { get; set; }

    public long HotelBookingId { get; set; }

    public string RoomTypeId { get; set; } = null!;

    public double Price { get; set; }

    public double Profit { get; set; }

    public double TotalAmount { get; set; }

    public string? RoomTypeCode { get; set; }

    public string? RoomTypeName { get; set; }

    public int? NumberOfAdult { get; set; }

    public int? NumberOfChild { get; set; }

    public int? NumberOfInfant { get; set; }

    public string? PackageIncludes { get; set; }

    public double? ExtraPackageAmount { get; set; }

    public int? Status { get; set; }

    public double? TotalUnitPrice { get; set; }

    public short? NumberOfRooms { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public long? SupplierId { get; set; }

    public bool? IsRoomFund { get; set; }
}
