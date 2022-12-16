using System;
using System.Collections.Generic;

namespace BlazorModel.Models
{
    public partial class MonHoc
    {
        public MonHoc()
        {
            Lops = new HashSet<Lop>();
        }

        public string MaMh { get; set; } = null!;
        public string TenMh { get; set; } = null!;

        public virtual ICollection<Lop> Lops { get; set; }
    }
}
