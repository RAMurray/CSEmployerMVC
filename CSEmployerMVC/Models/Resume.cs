using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSEmployerMVC.Models
{
    public class Resume
    {
        public int ID { get; set; }
        
        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        public virtual Applicant Applicant { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string Degree { get; set; }

        [Range(1, 100)]
        public int YearsExp { get; set; }

        [Required]
        public string Languages { get; set; }

    }
   /* public class ResumeDBContext : DbContext
    {
        public DbSet<Resume> Resumes { get; set; }
    }*/
}