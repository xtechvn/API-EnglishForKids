using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class QuizAnswer
{
    public int Id { get; set; }

    public int? QuizId { get; set; }

    public string? Description { get; set; }

    public short? Order { get; set; }

    public string? Thumbnail { get; set; }

    public int? Status { get; set; }

    public bool? IsCorrectAnswer { get; set; }

    public string? Note { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
