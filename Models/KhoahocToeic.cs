using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Group11.Models
{
    public class KhoahocToeic
    {
        public string ID { get; set; }

        [Display(Name = "Tên khóa học")]
        public byte[] Picture { get; set; }

        [NotMapped]
        [Display(Name = "Hình ảnh")]
        public HttpPostedFileBase PictureUpload { get; set; }
        [Display(Name = "Tên Khóa Học")]
        public string TenKH { get; set; }
        [Display(Name = "Giáo viên")]
        public string GiaoVien { get; set; }
        [Display(Name = "Thời gian khóa học")]
        public string Thoigian { get; set; }
        [Display(Name = "Nội dung")]
        public string Noidung { get; set; }
        [Display(Name = "Giáo trình")]
        public string Giaotrinh { get; set; }
        [Display(Name = "Hoạt động ngoại khóa")]
        public string hoatdong { get; set; }
        [Display(Name = "Học phí")]
        public string hocphi { get; set; }
    }
}