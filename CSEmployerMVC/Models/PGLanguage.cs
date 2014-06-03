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

        public string LanguageName { get; set; }

        public virtual ICollection<Applicant> Applicants { get; set; }

    }
}