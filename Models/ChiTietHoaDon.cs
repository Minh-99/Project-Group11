﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Group11.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int MaChiTietHoaDon { get; set; }
        [ForeignKey("HoaDonObj")]
        public int MaHoaDon { get; set; }
        public virtual HoaDon HoaDonObj { get; set; }
        [ForeignKey("MovieObj")]
        public int MaMovie { get; set; }
        public virtual Tailieu MovieObj { get; set; }
        public int SoLuong { get; set; }
    }
}