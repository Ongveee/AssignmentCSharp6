using System;
using System.Collections.Generic;

namespace BlazorModel.Models
{
    public partial class Diem
    {
        public int? MaSv { get; set; }
        public string? MaMh { get; set; }
        public double DiemDoc { get; set; }
        public double DiemPresentation { get; set; }

        public virtual MonHoc? MaMhNavigation { get; set; }
        public virtual SinhVien? MaSvNavigation { get; set; }
    }
}
