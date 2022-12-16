using System;
using System.Collections.Generic;

namespace BlazorModel.Models
{
    public partial class Truong
    {
        public Truong()
        {
            SinhViens = new HashSet<SinhVien>();
        }

        public string MaTruong { get; set; } = null!;
        public string? TenTruong { get; set; }

        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
