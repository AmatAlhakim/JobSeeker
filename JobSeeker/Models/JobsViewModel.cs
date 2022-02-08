using System;
using System.Collections.Generic;

namespace JobSeeker.Models
{
    public class JobsViewModel
    {
        public string JobTitle { get; set; }
        public IEnumerable<JobApplication> Items { get; set; }
    }
}