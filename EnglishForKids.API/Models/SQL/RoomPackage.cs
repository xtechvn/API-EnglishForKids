using System;
using System.Collections.Generic;

namespace HuloToys_Service.Models.SQL;

public partial class RoomPackage
{
    public int Id { get; set; }

    public string? PackageId { get; set; }

    public string? Code { get; set; }

    public int? RoomFunId { get; set; }

    public string? Description { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? UpdateLast { get; set; }

    public virtual RoomFun? RoomFun { get; set; }

    public virtual ICollection<ServicePiceRoom> ServicePiceRooms { get; set; } = new List<ServicePiceRoom>();
}
