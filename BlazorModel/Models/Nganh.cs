using System;
using System.Collections.Generic;

namespace BlazorModel.Models
{
    public partial class Nganh
    {
        public Nganh()
        {
            SinhViens = new HashSet<SinhVien>();
        }

        public string MaNganh { get; set; } = null!;
        public string TenNganh { get; set; } = null!;

        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
