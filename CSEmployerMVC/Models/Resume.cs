using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSEmployerMVC.Models
{
    public class Resume
    {
        //public int ID { get; set; }
        
        [Key]
        [ForeignKey("Applicant")]
        public int ApplicantID { get; set; }

        public virtual Applicant Applicant { get; set; }

        //[ValidateFile(ErrorMessage = "Please select a PNG image smaller than 1MB")]
        public byte[] FileData { get; set; }

        public string Content { get; set; }

        public string FileName { get; set; }
    }
}