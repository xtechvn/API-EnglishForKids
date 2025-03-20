using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class HotelSupplier
{
    public long Id { get; set; }

    public long HotelId { get; set; }

    public long SupplierId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
