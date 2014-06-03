using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSEmployerMVC.Models
{
    public class Resume
    {
        [Key]
        [ForeignKey("Applicant")]
        public int ApplicantID { get; set; }

        public virtual Applicant Applicant { get; set; }

        public bool Imported { get; set; } //If true Applicant has resume on site.

        //School Information
        [Display(Name = "School Name")]
        public string SchoolName { get; set; }
        
        public string DegreeEarned { get; set; }

        public string SchoolStayLength { get; set; }

        //Last Employer information
        [Display(Name = "Previous Employer")]
        public string LastEmployer { get; set; }
        
        public string LastJobTitle { get; set; }

        public string LastJobLength { get; set; }

        [Display(Name = "Job Duties")]
        [DataType(DataType.MultilineText)]
        public string PreviousJobDuties { get; set; }
        
        //Skills
        [DataType(DataType.MultilineText)]
        public string ContentSkills { get; set; }

    }
}