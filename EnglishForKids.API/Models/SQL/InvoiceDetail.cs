﻿using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class InvoiceDetail
{
    public long Id { get; set; }

    public long? InvoiceId { get; set; }

    public long? InvoiceRequestId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
