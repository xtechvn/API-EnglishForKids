using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class Passenger
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? MembershipCard { get; set; }

    public string PersonType { get; set; } = null!;

    public DateTime? Birthday { get; set; }

    public bool Gender { get; set; }

    public long OrderId { get; set; }

    public string? Note { get; set; }

    public string? GroupBookingId { get; set; }

    public virtual Order Order { get; set; } = null!;
}
