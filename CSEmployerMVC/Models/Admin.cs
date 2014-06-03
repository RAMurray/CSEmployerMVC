using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/* This class was created so that all the objects of each class can be displayed in the admin views */

namespace CSEmployerMVC.Models
{
    public class Admin
    {
        public IEnumerable<Applicant> Applicants { get; set; }
        public IEnumerable<Employer> Employers { get; set; }
        public IEnumerable<Job> Jobs { get; set; }
        public IEnumerable<PGLanguage> PGLanguages { get; set; }
        public IEnumerable<Resume> Resumes { get; set; }
    }
}