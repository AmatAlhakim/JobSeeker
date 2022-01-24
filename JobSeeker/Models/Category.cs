using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobSeeker.Models
{
    public class Category
    {
        public int id { get; set; }
        [Required]
        [Display(Name ="Job Category")]
        public string category { get; set; }
        [Required]
        [Display(Name ="Category Description")]
        public string description { get; set; }
    }
}