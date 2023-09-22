using System;
using System.Collections.Generic;

namespace EF_databaseFirst.Models;

public partial class Ve
{
    public string MaVe { get; set; } = null!;

    public string MaHoaDon { get; set; } = null!;

    public string GiaVe { get; set; } = null!;

    public string MaSc { get; set; } = null!;

    public string Hang { get; set; } = null!;

    public int? Cot { get; set; }

    public virtual HoaDon MaHoaDonNavigation { get; set; } = null!;

    public virtual SuatChieu MaScNavigation { get; set; } = null!;
}
