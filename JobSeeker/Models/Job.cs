using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

namespace JobSeeker.Models
{
    public class Job
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }
        [Required]
        [DisplayName("Job Description")]
        public string JobDescription { get; set; }
        [DisplayName("Job Image")]
        public string JobImage { get; set; }
        [DisplayName("Job Status")]
        public string JobStatus { get; set; }
        [Required]
        [DisplayName("Job Category")]
        public int CategoryId { get; set; }
        [DisplayName("Publisher Name")]
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<JobApplication> JobApplications { get; set; }

    }
}