using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Group11.Models
{
    public class Genre
    {
        [Key]
        public int genreID { get; set; }
        [Display(Name = "Thể loại")]
        [Required]
        [StringLength(100)]
        public string genreName { get; set; }
    }
}