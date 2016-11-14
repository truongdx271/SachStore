﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SachApp.Service.Models
{
    public class Sach
    {
        public int MASACH { get; set; }

        [StringLength(500)]
        public string TENSACH { get; set; }

        public int? MATHELOAI { get; set; }

        public int? NAMXUATBAN { get; set; }

        public decimal? GIAMUA { get; set; }

        public decimal? GIABAN { get; set; }

        public int? SOLUONGKHO { get; set; }

        public int? MANXB { get; set; }

        [StringLength(500)]
        public string MOTA { get; set; }


    }
}
