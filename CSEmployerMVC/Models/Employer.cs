using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSEmployerMVC.Models
{
    public class Employer
    {
        public int ID { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [StringLength(30)]
        public string Address { get; set; }

        [StringLength(10)]
        public string Zip { get; set; }

        [Required]
        [StringLength(30)]
        public string City { get; set; }

        [Required]
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

        /* Login information */

        [Required]
        public string eUsername { get; set; }

        [Required]
        public string ePassword { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}