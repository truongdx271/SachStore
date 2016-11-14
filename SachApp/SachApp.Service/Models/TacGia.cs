﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SachApp.Service.Models
{
    public class TacGia
    {
        public int MATG { get; set; }

        [StringLength(500)]
        public string TENTG { get; set; }

        [StringLength(500)]
        public string GIOITHIEU { get; set; }

        [StringLength(500)]
        public string DIACHI { get; set; }

        public int? DIENTHOAI { get; set; }

        [StringLength(500)]
        public string EMAIL { get; set; }
    }
}
