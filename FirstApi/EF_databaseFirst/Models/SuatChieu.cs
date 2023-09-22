using System;
using System.Collections.Generic;

namespace EF_databaseFirst.Models;

public partial class SuatChieu
{
    public string MaSc { get; set; } = null!;

    public string MaPhim { get; set; } = null!;

    public DateTime Ngay { get; set; }

    public DateTime BatDau { get; set; }

    public string MaPhong { get; set; } = null!;

    public virtual Phim MaPhimNavigation { get; set; } = null!;

    public virtual PhongChieu MaPhongNavigation { get; set; } = null!;

    public virtual ICollection<Ve> Ves { get; set; } = new List<Ve>();
}
