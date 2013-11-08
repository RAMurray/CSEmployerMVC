using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSEmployerMVC.Models
{
    public class PGLanguage
    {

        public int ID { get; set; }

        [HiddenInput]
        public string PglNameBase { get; set; }

        [Required]
        [HiddenInput]
        public int ConfigId { get; set; }  //This value is used a indentifier to help with the Database configuration process

        public virtual ICollection<Applicant> Applicants { get; set; }

    }
}