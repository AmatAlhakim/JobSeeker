using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobSeeker.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Application Message")]
        public string Message { get; set; }
        [DisplayName("Application Date")]
        public DateTime ApplicationDate { get; set; }
        public int JobId { get; set; }
        public string UserId { get; set; }
        public virtual Job job { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}