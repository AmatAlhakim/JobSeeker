﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JobSeeker.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name ="Email Subject")]
        public string Subject { get; set; }
        [Display(Name ="Email Content")]
        [Required]
        public string Message { get; set; }
        [Required]
        
        public string Phone { get; set; }

    }
}