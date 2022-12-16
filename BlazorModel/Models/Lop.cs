using System;
using System.Collections.Generic;

namespace BlazorModel.Models
{
    public partial class Lop
    {
        public Lop()
        {
            SinhViens = new HashSet<SinhVien>();
        }

        public string MaLop { get; set; } = null!;
        public string? MaMh { get; set; }
        public string TenLop { get; set; } = null!;

        public virtual MonHoc? MaMhNavigation { get; set; }
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}