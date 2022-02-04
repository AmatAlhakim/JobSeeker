using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobSeeker.Models
{
    public class ApplyForJob
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Application Message")]
        public string Message { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int JobId { get; set; }
        public string UserId { get; set; }
        public virtual Job Job { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}