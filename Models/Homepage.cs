using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity;
using System.Linq;
using System.Web;
namespace Group11.Models
{
    public class Homepage
    {
        [Key]
        public int IDlich { get; set; }
        //slide
        [Display(Name = "Hình slide 1")]
        public string Picture1 { get; set; }
        [Display(Name = "Hình slide 2")]

        public string Picture2 { get; set; }
        [Display(Name = "Hình slide 3")]

        public string Picture3 { get; set; }
        [Display(Name = "Hình slide 4")]

        public string Picture4 { get; set; }
        [Display(Name = "Hình slide 5")]

        public string Picture5 { get; set; }
        [Display(Name = "Foreign Follower")]

        public string ForeignFollower { get; set; }
        [Display(Name = "Students Enrolled")]
        public string StudentsEnrolled { get; set; }
        [Display(Name = "Classes Complete")]
        public string ClassesComplete { get; set; }
        [Display(Name = "Certified Teachers")]
        public string CertifiedTeachers { get; set; }
        [Display(Name = "Hình Giáo viên")]

        public string PictureGV { get; set; }
        [Display(Name = "Tên Giáo viên")]

        public string TenGV { get; set; }
        [Display(Name = "Mô tả Giáo viên")]

        public string MotaGV { get; set; }
        [Display(Name = "Hình Giáo viên 1")]

        public string PictureGV1 { get; set; }
        [Display(Name = "Tên Giáo viên 1")]

        public string TenGV1 { get; set; }
        [Display(Name = "Mô tả Giáo viên 1")]

        public string MotaGV1 { get; set; }
        [Display(Name = "Hình Giáo viên 2")]

        public string PictureGV2 { get; set; }
        [Display(Name = "Tên Giáo viên 2")]

        public string TenGV2 { get; set; }
        [Display(Name = "Mô tả Giáo viên 2")]

        public string MotaGV2 { get; set; }
        //HV
        [Display(Name = "Hình Học viên ")]

        public string PictureHV { get; set; }
        [Display(Name = "Tên Học viên ")]

        public string TenHV { get; set; }
        [Display(Name = "Điểm Học viên ")]

        public string DiemHV { get; set; }
        [Display(Name = "Hình Học viên 1 ")]

        public string PictureHV1 { get; set; }
        [Display(Name = "Tên Học viên 1 ")]

        public string TenHV1 { get; set; }
        [Display(Name = "Điểm Học viên 1 ")]

        public string DiemHV1 { get; set; }
        [Display(Name = "Hình Học viên 2 ")]

        public string PictureHV2 { get; set; }
        [Display(Name = "Tên Học viên 2")]

        public string TenHV2 { get; set; }
        [Display(Name = "Điểm Học viên 2")]

        public string DiemHV2 { get; set; }
        [Display(Name = "Hình Học viên 3 ")]

        public string PictureHV3 { get; set; }
        [Display(Name = "Tên Học viên 3 ")]

        public string TenHV3 { get; set; }
        [Display(Name = "Điểm Học viên 3 ")]

        public string DiemHV3 { get; set; }
        [Display(Name = "Hình Học viên 4 ")]

        public string PictureHV4 { get; set; }
        [Display(Name = "Tên Học viên 4")]

        public string TenHV4 { get; set; }
        [Display(Name = "Điểm Học viên 4")]

        public string DiemHV4 { get; set; }
        [Display(Name = "Hình Học viên 5")]

        public string PictureHV5 { get; set; }
        [Display(Name = "Tên Học viên 5")]

        public string TenHV5 { get; set; }
        [Display(Name = "Điểm Học viên 5")]

        public string DiemHV5 { get; set; }

        [Display(Name = "Khóa học")]

        public string Khoahoc { get; set; }
        [Display(Name = "Mã khóa học")]

        public string Makhoahoc { get; set; }
        [Display(Name = "Lịch khai giảng")]

        public string Khaigiang { get; set; }
        [Display(Name = "Thời gian")]

        public string Thoigian { get; set; }
        [Display(Name = "Lịch học")]

        public string lichhoc { get; set; }
        [Display(Name = "Số buổi")]

        public int sobuoi { get; set; }
        [Display(Name = "Khóa học 1")]

        public string Khoahoc1 { get; set; }
        [Display(Name = "Mã khóa học 1")]

        public string Makhoahoc1 { get; set; }
        [Display(Name = "Lịch khai giảng 1")]

        public string Khaigiang1 { get; set; }
        [Display(Name = "Thời gian 1")]

        public string Thoigian1 { get; set; }
        [Display(Name = "Lịch học 1")]

        public string lichhoc1 { get; set; }
        [Display(Name = "Số buổi 1")]
        public int sobuoi1 { get; set; }

        [Display(Name = "Khóa học 2")]

        public string Khoahoc2 { get; set; }
        [Display(Name = "Mã khóa học 2")]

        public string Makhoahoc2 { get; set; }
        [Display(Name = "Lịch khai giảng 2")]

        public string Khaigiang2 { get; set; }
        [Display(Name = "Thời gian 2")]

        public string Thoigian2 { get; set; }
        [Display(Name = "Lịch học 2")]

        public string lichhoc2 { get; set; }
        [Display(Name = "Số buổi 2")]

        public int sobuoi2 { get; set; }
        [Display(Name = "Khóa học 3")]

        public string Khoahoc3 { get; set; }
        [Display(Name = "Mã khóa học 3")]

        public string Makhoahoc3 { get; set; }
        [Display(Name = "Lịch khai giảng 3")]

        public string Khaigiang3 { get; set; }
        [Display(Name = "Thời gian 3")]

        public string Thoigian3 { get; set; }
        [Display(Name = "Lịch học ")]

        public string lichhoc3 { get; set; }
        [Display(Name = "Số buổi 3")]

        public int sobuoi3 { get; set; }
        //4
        [Display(Name = "Khóa học 4")]

        public string Khoahoc4 { get; set; }
        [Display(Name = "Mã khóa học 4")]

        public string Makhoahoc4 { get; set; }
        [Display(Name = "Lịch khai giảng 4")]

        public string Khaigiang4 { get; set; }
        [Display(Name = "Thời gian 4")]

        public string Thoigian4 { get; set; }
        [Display(Name = "Lịch học 4")]

        public string lichhoc4 { get; set; }
        [Display(Name = "Số buổi 4")]

        public int sobuoi4 { get; set; }

    }
}