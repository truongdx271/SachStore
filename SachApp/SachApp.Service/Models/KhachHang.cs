using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SachApp.Service.Models
{
    public class KhachHang
    {
        public int MAKH { get; set; }

        [StringLength(500)]
        public string TENKH { get; set; }

        public int? DIENTHOAI { get; set; }

        [StringLength(500)]
        public string DIACHI { get; set; }
    }
}
