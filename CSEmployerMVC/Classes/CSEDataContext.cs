using CSEmployerMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CSEmployerMVC.Classes
{
    public class CSEDataContext : DbContext
    {
        
           static CSEDataContext()
            {
                Database.SetInitializer<DbContext>(null);
            }

            public DbSet<Applicant> Applicants { get; set; }
            public DbSet<Employer> Employers { get; set; }
            public DbSet<Job> Jobs { get; set; }
            public DbSet<Resume> Resumes { get; set; }
            public DbSet<PGLanguage> ProLanguage { get; set; }
        
            protected void OnModelCreating(DbModelBuilder modelBuilder)
            {
 
                //Applicant has a 1-to-1 relationship with Resume. A Resume can only exist if associated with an Applicant.
                modelBuilder.Entity<Resume>()
                           .HasRequired(m => m.Applicant)
                           .WithMany()
                           .HasForeignKey(mri => mri.ApplicantID).WillCascadeOnDelete(false);

                //Sets up a many-to-many relationship with Applicant and ProLanguages by go
                modelBuilder.Entity<Applicant>().
                          HasMany(c => c.PGLanguages).
                          WithMany(p => p.Applicants).
                          Map(
                           m =>
                           {
                               m.MapLeftKey("ApplicantID");
                               m.MapRightKey("PLanguageID");
                               m.ToTable("APL");
                           });
                   //Sets up many-to-many relationship with Jobs and Applicants.
                   modelBuilder.Entity<Job>()
                     .HasMany(a => a.Applicants).WithMany(j => j.Jobs)
                     .Map(
                     t => 
                     {    
                        t.MapLeftKey("JobID");
                        t.MapRightKey("ApplicantID");
                        t.ToTable("JobApplicant");
                     });
              }
            

        
   }
}