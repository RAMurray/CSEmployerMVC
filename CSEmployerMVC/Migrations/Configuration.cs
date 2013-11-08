namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CSEmployerMVC.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<CSEmployerMVC.Classes.CSEDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CSEmployerMVC.Classes.CSEDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            /*
            var applicants = new List<Applicant>
            {
                new Applicant { FName ="Danny", LName="Danielson", DOB= DateTime.Parse("1990-03-15"),
                    Address="233 Shield Street", Zip="98007", City="Seatle", State="WA", Country="United States of America",
                    Phone="", Fax="", Email="dbrown90@gmail.net", Degree=Bachelors, YearsExp=1,
                    KnownPL1 = "C++", KnownPL2="C#", KnownPL3="SQL", KnownPL4="HTML", KnownPL5="PHP"},

                new Applicant { FName ="Miley", LName="Li", DOB= DateTime.Parse("1982-07-22"),
                    Address="3402 Grapevine drive", Zip="07223", City="Newark", State="NJ", Country="United States of America",
                    Phone="555-555-2344", Fax="", Email="blackwidow44@yahoo.net", Degree= Masters, YearsExp=3,
                    KnownPL1 = "Objective-C", KnownPL2="Java", KnownPL3="SQL", KnownPL4="Python", KnownPL5="VisualBasic",},

                 new Applicant { FName ="Hal", LName="Saxton", DOB= DateTime.Parse("1975-11-09"),
                    Address="45 Dropbear Lane", Zip="", City="Melbourne", State="", Country="Australia",
                    Phone="1-555-555-1700", Fax="", Email="halsaxy2000@hotmail.org", Degree="PHD", YearsExp=5,
                    KnownPL1 = "C", KnownPL2="NXT-G", KnownPL3="Bash", KnownPL4="Assembly", KnownPL5="COBOL"},

                 new Applicant { FName ="Lisa", LName="Johnson", DOB= DateTime.Parse("1989-04-04"),
                    Address="345 Rhodes Creek Apt. 42", Zip="32001", City="Tampa Bay", State="FL", Country="United States of America",
                    Phone="555-555-3004", Fax="555-555-3444", Email="Lisa.Fleming@gmail.net", Degree="GED", YearsExp=4,
                    KnownPL1 = "HTML", KnownPL2="CSS", KnownPL3="JavaScript", KnownPL4="MATLAB", KnownPL5="ActionScript"},

                  new Applicant { FName ="Kendrick", LName="Frogsworth", DOB= DateTime.Parse("1985-02-14"),
                    Address="301 Diamondhedge Ln", Zip="", City="Los Angeles", State="CA", Country="United States of America",
                    Phone="1-555-555-1234", Fax="", Email="chocodrop234@hotmail.org", Degree="Bachelor's", YearsExp=0,
                    KnownPL1 = "Java", KnownPL2="Ruby", KnownPL3="Perl", KnownPL4="C#", KnownPL5=""}
            };
            applicants.ForEach(s => context.Applicants.AddOrUpdate(p => p.LName));
            */
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
                System.IO.File.AppendAllLines(@"C:\Users\murrayr\Documents\Visual Studio 2012\Projects\CSEmployerMVC\errors.txt", outputLines);
                throw;
            }

            var prolanguage = new List<PGLanguage>
            {
                new PGLanguage { PglNameBase = "C"},
                new PGLanguage { PglNameBase = "C++"},
                new PGLanguage { PglNameBase = "Objective-C"},
                new PGLanguage { PglNameBase = "C#"},
                new PGLanguage { PglNameBase = "Java"},
                new PGLanguage { PglNameBase = "JavaScript"},
                new PGLanguage { PglNameBase = "CSS"},
                new PGLanguage { PglNameBase = "HTML"},
                new PGLanguage { PglNameBase = "PHP"},
                new PGLanguage { PglNameBase = "Python"},
                new PGLanguage { PglNameBase = "SQL"},
                new PGLanguage { PglNameBase = "VisualBasic"},
                new PGLanguage { PglNameBase = "Perl"},
                new PGLanguage { PglNameBase = "Ruby"},
                new PGLanguage { PglNameBase = "Lisp"},
                new PGLanguage { PglNameBase = "Delphi"},
                new PGLanguage { PglNameBase = "Pascal"},
                new PGLanguage { PglNameBase = "MATLAB"},
                new PGLanguage { PglNameBase = "COBOL"},
                new PGLanguage { PglNameBase = "Groovy"},
                new PGLanguage { PglNameBase = "Ada"},
                new PGLanguage { PglNameBase = "Assembly"},
                new PGLanguage { PglNameBase = "Bash"},
                new PGLanguage { PglNameBase = "Haskell"},
                new PGLanguage { PglNameBase = "ActionScript"},
                new PGLanguage { PglNameBase = "NXT-G"},
                new PGLanguage { PglNameBase = "Fortran"}
            };
            //prolanguage.ForEach(s => context.PGLanguages.AddOrUpdate(p => p.ConfigId));

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
                System.IO.File.AppendAllLines(@"C:\Users\murrayr\Documents\Visual Studio 2012\Projects\CSEmployerMVC\errors.txt", outputLines);
                throw;
            }

            /* var apls = new List<APL>
             {
                 new APL {
                     ApplicantID = applicants.Single( a => a.LName == "Brown").ID,
                     PLanguageID = prolanguage.Single( p => p.KplID == 1).ID
                 },
                 new APL {
                     ApplicantID = applicants.Single( a => a.LName == "Li").ID,
                     PLanguageID = prolanguage.Single( p => p.KplID == 2).ID
                 },
                 new APL {
                     ApplicantID = applicants.Single( a => a.LName == "Saxton").ID,
                     PLanguageID = prolanguage.Single( p => p.KplID == 3).ID
                 },
                 new APL {
                     ApplicantID = applicants.Single( a => a.LName == "Fleming").ID,
                     PLanguageID = prolanguage.Single( p => p.KplID == 4).ID
                 },
                 new APL {
                     ApplicantID = applicants.Single( a => a.LName == "Hartfelt").ID,
                     PLanguageID = prolanguage.Single( sp => p.KplID == 5).ID
                 }
             };*/
        }


    }
}
