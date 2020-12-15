using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Group11.Models
{
    public class Tintuc
    {
        public string ID { get; set; }
        public byte[] Picture { get; set; }

        [NotMapped]
        [Display(Name = "Hình ảnh")]
        public HttpPostedFileBase PictureUpload { get; set; }
        [Display(Name = "Tiêu đề")]
        public string Tieude { get; set; }
        [Display(Name = "Nội dung")]
        public string Noidung { get; set; }
        [Display(Name = "Url Xem Thêm")]
        public string Xemthem { get; set; }
        
        
    }
}