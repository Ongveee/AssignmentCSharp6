using System;
using System.Collections.Generic;

namespace BlazorModel.Models
{
    public partial class SinhVien
    {
        public int MaSv { get; set; }
        public string TenSv { get; set; } = null!;
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? MaTruong { get; set; }
        public string? MaNganh { get; set; }
        public string? MaLop { get; set; }
        public byte[] Anh { get; set; } = null!;

        public virtual Lop? MaLopNavigation { get; set; }
        public virtual Nganh? MaNganhNavigation { get; set; }
        public virtual Truong? MaTruongNavigation { get; set; }
    }
}
