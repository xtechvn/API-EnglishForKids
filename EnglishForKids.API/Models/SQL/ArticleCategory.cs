using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class ArticleCategory
{
    public long Id { get; set; }

    public int? CategoryId { get; set; }

    public long? ArticleId { get; set; }
}
