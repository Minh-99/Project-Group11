using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Group11.Models
{
    public class Tailieu
    {
        public class GenreAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                int genreID = int.Parse(value.ToString());
                var db = new TailieuDBContext();
                if (db.genres.Any(x => x.genreID == genreID))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(ErrorMessage ?? "Genre khong ton tai");
            }
        }

        public class CurrentDateAttribute : ValidationAttribute
        {
            public CurrentDateAttribute()
            {
            }

            public override bool IsValid(object value)
            {
                var dt = (DateTime)value;
                if (dt <= DateTime.Now)
                {
                    return true;
                }
                return false;
            }
        }
        public int ID { get; set; }
        [Display(Name = "Tên tài liệu")]

        [StringLength(200, MinimumLength = 3)]
        public string Title { get; set; }

        [Display(Name = "Ngày xuất bản")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [CurrentDate(ErrorMessage = "Ngày ra mắt phải nhỏ hơn hôm nay")]
        public DateTime ReleaseDate { get; set; }

        [ForeignKey("GenresObj")]
        [Display(Name = "Thể loại tài liệu")]
        [Genre]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required]
        public int GenreID { get; set; }

        public virtual Genre GenresObj { get; set; }

        [Display(Name = "Giá tiền")]
        [Range(5000, double.MaxValue)]
        [DisplayFormat(DataFormatString = "{0:0,0}đ")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public byte[] Picture { get; set; }

        [NotMapped]
        [Display(Name = "Hình ảnh")]
        public HttpPostedFileBase PictureUpload { get; set; }

        [Display(Name = "Đánh giá")]
        [RegularExpression("^[0-9]*$")]
        [Range(1, 5)]
        public string Rating { get; set; }

        [Display(Name = "Tóm tắt")]
        [StringLength(int.MaxValue, MinimumLength = 10)]
        public string Sumary { get; set; }
    }
}