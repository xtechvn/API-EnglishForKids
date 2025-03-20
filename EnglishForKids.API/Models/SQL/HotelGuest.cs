using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class HotelGuest
{
    public long Id { get; set; }

    public long HotelBookingRoomsId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? Birthday { get; set; }

    public long HotelBookingId { get; set; }

    public string? Note { get; set; }

    public short? Type { get; set; }
}
