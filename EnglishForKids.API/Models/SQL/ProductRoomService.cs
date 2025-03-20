using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class ProductRoomService
{
    public int Id { get; set; }

    public int CampaignId { get; set; }

    public long? ProgramId { get; set; }

    public int? ProgramPackageId { get; set; }

    public int? HotelId { get; set; }

    public string? AllotmentsId { get; set; }

    public string? PackageCode { get; set; }

    public int? RoomId { get; set; }
}
