using System;
using System.Collections.Generic;

namespace EF_databaseFirst.Models;

public partial class Phim
{
    public string MaPhim { get; set; } = null!;

    public byte[] ThoiLuong { get; set; } = null!;

    public string? TenPhim { get; set; }

    public string TheLoai { get; set; } = null!;

    public virtual ICollection<SuatChieu> SuatChieus { get; set; } = new List<SuatChieu>();
}
