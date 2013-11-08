using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSEmployerMVC.Models
{

    public enum Degrees
    {
        GED,
        Certificate,
        Bachelors,
        Masters,
        PHD
    }


    public class Applicant
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }


        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy MMM d}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [StringLength(30)]
        public string Address { get; set; }

        [StringLength(10)]
        public string Zip { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        [StringLength(2)]
        public string State { get; set; }

        [Required]
        [StringLength(30)]
        public string Country { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(16)]
        public string Phone { get; set; }

        [StringLength(16)]
        public string Fax { get; set; }

        [Required]
        [UIHint("Enum")]
        public Degrees Degree { get; set; }

        [Display(Name = "Years Exp.")]
        [Required]
        public int YearsExp { get; set; }

        //Programing Langauges
        public string KnownPL1 { get; set; }

        public string KnownPL2 { get; set; }

        public string KnownPL3 { get; set; }

        public string KnownPL4 { get; set; }

        public string KnownPL5 { get; set; }


        public virtual List List { get; set; }
        public ICollection<PGLanguage> PGLanguages { get; set; }

        public string FullName
        {
            get { return FName + " " + LName; }
        }

        public string Location
        {
            get { return City + ", " + State + ", " + Country; }
        }

        public string KnownLanguages
        {
            get { return KnownPL1 + " " + KnownPL2 + " " + KnownPL3 + " " + KnownPL4 + " " + KnownPL5; }
        }

    }
}