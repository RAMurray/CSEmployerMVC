using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSEmployerMVC.Models
{
    public class List
    {
        [Key]
        [ForeignKey("Job")]
        public int JobID { get; set; }

        public virtual Job Job { get; set; }
        public virtual ICollection<Applicant> Applicants { get; set; }
    }
}