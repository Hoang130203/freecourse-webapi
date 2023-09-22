using System;
using System.Collections.Generic;

namespace EF_databaseFirst.Models;

public partial class HoaDon
{
    public string MaHoaDon { get; set; } = null!;

    public string TongGia { get; set; } = null!;

    public string HinhThucThanhToan { get; set; } = null!;

    public string MaTaiKhoan { get; set; } = null!;

    public DateTime ThoiGian { get; set; }

    public virtual TaiKhoan MaTaiKhoanNavigation { get; set; } = null!;

    public virtual ICollection<Ve> Ves { get; set; } = new List<Ve>();
}
