using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class QuizResult
{
    public int Id { get; set; }

    public int SourceId { get; set; }

    public int QuizId { get; set; }

    public int? QuizAnswerId { get; set; }

    public int? UserId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
