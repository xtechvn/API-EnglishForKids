using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class HotelRoom
{
    public int Id { get; set; }

    public long HotelId { get; set; }

    public string RoomId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public int? NumberOfBedRoom { get; set; }

    public string? Description { get; set; }

    public string? TypeOfRoom { get; set; }

    public string? Thumbnails { get; set; }

    public string? Extends { get; set; }

    public int? BedRoomType { get; set; }

    public int? NumberOfAdult { get; set; }

    public int? NumberOfChild { get; set; }

    public int? NumberOfRoom { get; set; }

    public double? RoomArea { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsDisplayWebsite { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? RoomAvatar { get; set; }

    public string? Avatar { get; set; }
}
