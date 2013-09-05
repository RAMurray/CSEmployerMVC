using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Applicant
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [StringLength(2)]
        public string State { get; set; }

        [Required]
        public string Degree { get; set; }

        [Range(1, 100)]
        public int YearsExp { get; set; }

        [Required]
        public string Languages { get; set; }
       
    }
    public class ApplicantDBContext : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }
    }
}