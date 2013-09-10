namespace CSEmployerMVC.Migrations
{
    using CSEmployerMVC.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CSEmployerMVC.Models.ApplicantDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CSEmployerMVC.Models.ApplicantDBContext context)
        {
            var applicants = new List<Applicant>
                {
                    new Applicant { FName = "Doug",   LName = "Funny", 
                        DOB = DateTime.Parse("1988-3-18"), City = "Bakersfield", State = "CA", Phone="555-555-1234", Email="thebeets88@aol.com",
                        JobTitle = "Programmer",
                        Degree = "Bachelor",
                        YearsExp = 2,
                        Languages = "C++ C C# HTML PHP CSS"
                    },
                    new Applicant { FName = "Elizabeth", LName = "Lemon",    
                        DOB = DateTime.Parse("1985-9-22"), City = "Chicago", State = "IL", Phone="555-555-000", Email="psychology3234@gmail.com",
                        JobTitle = "Software Engineer",
                        Degree = "Masters",
                        YearsExp = 4,
                        Languages = "Java C Objective-C Python"  
                    },
                    new Applicant { FName = "Jeese",   LName = "Pinkman",     
                        DOB = DateTime.Parse("1991-1-19"), City = "Alberquerque", State = "NM", Phone="555-555-4544", Email="chilipowder420@yahoo.com", 
                        JobTitle = "Web Designer",
                        Degree = "Bachelor",
                        YearsExp = 1,
                        Languages = "HTML5 Javascript CSS3 PHP Objective-C"
                    },
                    new Applicant { FName = "Gordon",    LName = "Freeman", 
                        DOB = DateTime.Parse("1974-11-08"), City = "Redmond", State = "WA", Phone="555-333-3333", Email="crowbarkilla99@blackmesa.com",
                        JobTitle = "Database Admin",
                        Degree = "PHD",
                        YearsExp = 5,
                        Languages = "Java SQL PHP Haskell C# Ruby Perl C"
                    },
                    new Applicant { FName = "Dean",    LName = "Amberose", 
                        DOB = DateTime.Parse("1989-6-12"), City = "Austin", State = "TX", Phone="1-800-555-3353", Email="sierrahotelnope343@gmail.com",
                        JobTitle = "IT",
                        Degree = "GED",
                        YearsExp = 7,
                        Languages = "Tech SQL PHP Python javascript"
                    },
                    new Applicant { FName = "Lana",      LName = "King",        
                        DOB = DateTime.Parse("1982-07-04"), City = "Bufallo", State = "NY", Phone="555-555-7777", Email="yuuuuuup82@hotmail.com",
                        JobTitle = "Programmer 2",
                        Degree = "Masters",
                        YearsExp = 1,
                        Languages = "C++ C C# Objective-C Java"
                    },
                    new Applicant { FName = "Keanu",    LName = "Reaves",
                        DOB = DateTime.Parse("1910-10-10"), City = "Hell", State = "MI", Phone="555-555-5555", Email="email@live.com",
                        JobTitle = "System Analyist",
                        Degree = "PHD",
                        YearsExp = 99,
                        Languages = "Cobol Assembly" 
                    }
                };
            applicants.ForEach(s => context.Applicants.AddOrUpdate(p => p.LName, s));
            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
                        DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format(
                            "- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"c:\temp\errors.txt", outputLines);
                throw;
            }
        }
    }
}