using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSEmployerMVC.Models
{
    public enum Rate
    {
        Hour,
        Week,
        BiWeek,
        Month,
        Year
    }


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

        public string PositionType { get; set; }

        [Range(0, 168)]
        public int HoursPerWeek { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public double Salary { get; set; }

        [UIHint("Enum")]
        public Rate PayRate { get; set; }

        [UIHint("Enum")]
        public Degrees reqDegree { get; set; }

        public int reqYearsExp { get; set; }

        public string reqPGLanguages { get; set; }

        [DisplayFormat(DataFormatString = "{0:MMM d yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DatePosted { get; set; }
     
        [ForeignKey("Employer")]
        public int EmployerID { get; set; }

        public virtual Employer Employer { get; set; }
        public ICollection<Applicant> Applicants { get; set; }

        public string TotalPayString
        {
            get { return "$" + Salary + " per " + PayRate; }
        }

    }
}