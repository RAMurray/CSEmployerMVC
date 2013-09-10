using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CSEmployerMVC.Models
{
    public class Applicant
    {
        public int ID { get; set; }

        [Required]
        public string FName { get; set; }

        [Required]
        public string LName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        [Required]
        [StringLength(2)]
        public string State { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(16)]
        public string Phone { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string Degree { get; set; }

        [Range(1, 100)]
        public int YearsExp { get; set; }

        [Required]
        public string Languages { get; set; }

        public string FullName
        {
            get { return FName + " " + LName; }
        }

        public string Experience
        {
            get { return YearsExp + " Years"; }
        }

        public string Location
        {
            get { return City + ", " + State; }
        }

        //public virtual ICollection<Resume> Resume { get; set; }

    }
    public class ApplicantDBContext : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }
    }
}