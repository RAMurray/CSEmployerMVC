using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSEmployerMVC.Models
{
    public class Job
    {
        public int ID { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Recruiter { get; set; }

        [Required]
        public string Location { get; set; }

        public string Candidates { get; set;  }

        public List<Applicant> CandidatesList { get; set; }
     


        [ForeignKey("Employer")]
        public int EmployerID { get; set; }

        public virtual Employer Employer { get; set; }
        public ICollection<Applicant> Applicants { get; set; }

    }
}