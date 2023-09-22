using System;
using System.Collections.Generic;

namespace EF_databaseFirst.Models;

public partial class Rap
{
    public string MaRap { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public decimal DanhGia { get; set; }

    public string TenRap { get; set; } = null!;

    public virtual ICollection<PhongChieu> PhongChieus { get; set; } = new List<PhongChieu>();
}
