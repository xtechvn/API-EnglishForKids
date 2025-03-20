using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class ProductFlyTicketService
{
    public int Id { get; set; }

    public int CampaignId { get; set; }

    public string GroupProviderType { get; set; } = null!;

    public virtual Campaign Campaign { get; set; } = null!;
}
