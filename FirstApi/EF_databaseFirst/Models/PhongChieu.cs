using System;
using System.Collections.Generic;

namespace EF_databaseFirst.Models;

public partial class PhongChieu
{
    public string MaPhong { get; set; } = null!;

    public string TenPhong { get; set; } = null!;

    public string MaRap { get; set; } = null!;

    public string LoaiPhong { get; set; } = null!;

    public virtual Rap MaRapNavigation { get; set; } = null!;

    public virtual ICollection<SuatChieu> SuatChieus { get; set; } = new List<SuatChieu>();
}
