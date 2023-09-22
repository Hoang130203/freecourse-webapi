using System;
using System.Collections.Generic;

namespace EF_databaseFirst.Models;

public partial class TaiKhoan
{
    public string MaTaiKhoan { get; set; } = null!;

    public string TenKhachHang { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
