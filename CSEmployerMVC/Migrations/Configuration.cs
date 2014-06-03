namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CSEmployerMVC.Models;
    using System.Collections.Generic;
    using System.IO;

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

            //var applicants = new List<Applicant>
            //{
            //    new Applicant { FName="Sid", LName="Myers", DOB=DateTime.Parse("1988-04-15"), Address="24 Crystal Cove Lane", Zip="77000" , City="Austin", State="TX", Country="USA", 
            //        Email="Arghmatey@yahoo.biz", Phone="555-558-7723", Fax="", Degree= Degrees.Masters ,YearsExp= 5 , KnownPL1="Ruby", KnownPL2="Perl", KnownPL3="Objective-C", KnownPL4="Java", KnownPL5="" },
            //    new Applicant { FName="Cynthia", LName="Gomez", DOB=DateTime.Parse("1981-04-14"), Address="Sur 111-A 2409 Tlacotal Ramos Millán", Zip="", City="Mexico City", State="", Country="Mexico", 
            //        Email="CynthiadelGomez@google.net", Phone="1-555-2222", Fax="", Degree=Degrees.Masters, YearsExp=2, KnownPL1="Java", KnownPL2="PHP", KnownPL3="SQL", KnownPL4="ColdFusion", KnownPL5="Haskell" },

            //    new Applicant { FName="Peter", LName="Hernandez", DOB=DateTime.Parse("1974-09-22"), Address="881 PeachTree Ln", Zip="39800", City="Atlanta", State="GA", Country="USA", 
            //        Email="PeterHenandez74@google.org", Phone="555-787-4421", Fax="1-555-555-8887", Degree=Degrees.Bachelors, YearsExp=6, KnownPL1="C#", KnownPL2="SQL", KnownPL3="PHP", KnownPL4="HTML", KnownPL5="" },

            //   new Applicant { FName="Tonya", LName="Matlock", DOB=DateTime.Parse("1992-07-13"), Address="34 Burger Lane", Zip="84001", City="Reno", State="NV", Country="USA", 
            //        Email="TonyataPruis@yahoo.biz", Phone="555-783-1006", Fax="", Degree=Degrees.GED, YearsExp=2, KnownPL1="Python", KnownPL2="Javascrpit", KnownPL3="HTML", KnownPL4="CSS", KnownPL5="ActionScript" },

            //     new Applicant { FName="Aubery", LName="Black", DOB=DateTime.Parse("1985-12-01"), Address="18th Street", Zip="", City="Toronto", State="ON", Country="Canada", 
            //        Email="Startedatthebottom@hotmail.net", Phone="1-555-333-2212", Fax="", Degree=Degrees.Bachelors, YearsExp=0, KnownPL1="C++", KnownPL2="SQL", KnownPL3="C#", KnownPL4="ColdFusion", KnownPL5="" },

            // new Applicant { FName="Kai", LName="Nguyen", DOB=DateTime.Parse("1974-10-18"), Address="388 Liu Xia Lu", Zip="", City="Shanghai", State="", Country="China", 
            //        Email="KaiNguyen@google.net", Phone="1-555-882-0012", Fax="01-555-5512", Degree=Degrees.PHD, YearsExp=3, KnownPL1="C", KnownPL2="NXT-G", KnownPL3="MATLAB", KnownPL4="Assembly", KnownPL5="Java" },
            //new Applicant { FName="Heidi", LName="Hidenwright", DOB=DateTime.Parse("1982-05-10"), Address="Auerhahnstraße 56", Zip="65933 ", City="Frankfurt", State="", Country="Germany", 
            //        Email="Heidi@google.net", Phone="02-555-5232", Fax="", Degree=Degrees.Bachelors, YearsExp=7, KnownPL1="C#", KnownPL2="SQL", KnownPL3="PHP", KnownPL4="", KnownPL5="" },
            //new Applicant { FName="Clair", LName="Jordan", DOB=DateTime.Parse("1991-04-14"), Address="454 Lake Drive", Zip="68552 ", City="Lincoln", State="NE", Country="USA", 
            //        Email="ClairJordan@google.net", Phone="", Fax="", Degree=Degrees.Certificate, YearsExp=3, KnownPL1="C++", KnownPL2="HTML", KnownPL3="JavaScript", KnownPL4="", KnownPL5="" }

            //};
            //applicants.ForEach(s => context.Applicants.AddOrUpdate(x => x.LName, s));
            //try
            //{
            //    context.SaveChanges();
            //}
            //catch (System.Data.Entity.Validation.DbEntityValidationException e)
            //{
            //    var outputLines = new List<string>();
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        outputLines.Add(string.Format(
            //            "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
            //            DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            outputLines.Add(string.Format(
            //                "- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage));
            //        }
            //    }
            //    //Error text file path: CSEmployerMVC\Migrations\errors.txt
            //    System.IO.File.AppendAllLines(@"C:\Temp\errors.txt", outputLines);
            //    throw;
            //}

            //var employers = new List<Employer>
            //{
            //    new Employer { CompanyName="Occidental Petroleum", Address="9201 Camino Media", Zip="93311", City="Bakersfield", State="CA", Country="USA", Email="careers@oxy.biz", Phone="661-664-1188", Fax="", ePassword="drillbaby" },
            //    new Employer { CompanyName="U.S. Department of Homeland Security", Address="355 12th Street", Zip="20528", City="Washington", State="DC", Country="USA", Email="dhscareers@usa.gov", Phone="202-282-8000", Fax="", ePassword="obama" },
            //    new Employer { CompanyName="Ecalix Inc.", Address="42840 Christy Street", Zip="94538", City="Fremont", State="CA", Country="USA", Email="Info@Ecalix.com", Phone="510-687-9015", Fax="", ePassword="guest" },
            //    new Employer { CompanyName="UbiSoft", Address="301 Seine-Saint-Denis", Zip="", City="Montreuil", State="", Country="France", Email="emplois@Ubisoft.com", Phone="05-555-8481", Fax="", ePassword="creeddogcry" },
            //    new Employer { CompanyName="Acne Inc", Address="512 Walter Ave", Zip="77125", City="Dallas", State="TX", Country="USA", Email="jobsInfo@cyberdyne.com", Phone="800-555-4532", Fax="", ePassword="robots" },
            //    new Employer { CompanyName="JPMorgan Chase", Address="270 Park Avenue", Zip="01542", City="Manhattan", State="NY", Country="USA", Email="careerInfo@Chase.com", Phone="1-212-270-6000", Fax="", ePassword="2007wooo" },
            //    new Employer { CompanyName="StartUp & Brothers", Address="210 SmallBiz lane", Zip="21488", City="Charlotte", State="NC", Country="USA", Email="2small4domain@gmail.net", Phone="555-810-5412", Fax="", ePassword="mini" },
            //    new Employer { CompanyName="Microsoft", Address="One Microsoft Way", Zip="98052", City="Redmond", State="WA", Country="USA", Email="careers8@Microsoft.com", Phone="800-555-5122", Fax="", ePassword="ballmerrules" },
            //    new Employer { CompanyName="Amazon.com Inc", Address="234 Amazon Way", Zip="98044", City="Seattle", State="WA", Country="USA", Email="jobinfo8@Amazon.com", Phone="1-888-280-3321", Fax="", ePassword="buybuybuy" },
            //    new Employer { CompanyName="California State University", Address="4542 Rockport way", Zip="93013", City="Sacramento", State="CA", Country="USA", Email="contact@csu.edu", Phone="1-888-332-5555", Fax="888-332-5551", ePassword="college" }
            //};
            //employers.ForEach(s => context.Employers.AddOrUpdate(x => x.CompanyName, s));
            //try
            //{
            //    context.SaveChanges();
            //}
            //catch (System.Data.Entity.Validation.DbEntityValidationException e)
            //{
            //    var outputLines = new List<string>();
            //    string currentdirectory = Directory.GetCurrentDirectory();
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        outputLines.Add(string.Format(
            //            "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
            //            DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            outputLines.Add(string.Format(
            //                "- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage));
            //        }
            //    }
            //    //Error text file path: CSEmployerMVC\Migrations\errors.txt
            //    System.IO.File.AppendAllLines(@"C:\Temp\errors.txt", outputLines);
            //    throw;
            //}

            
            //var prolanguage = new List<PGLanguage>
            //{
            //    new PGLanguage { LanguageName = "C"},
            //    new PGLanguage { LanguageName = "C++"},
            //    new PGLanguage { LanguageName = "Objective-C"},
            //    new PGLanguage { LanguageName = "C#"},
            //    new PGLanguage { LanguageName = "Java"},
            //    new PGLanguage { LanguageName = "JavaScript"},
            //    new PGLanguage { LanguageName = "CSS"},
            //    new PGLanguage { LanguageName = "HTML"},
            //    new PGLanguage { LanguageName = "PHP"},
            //    new PGLanguage { LanguageName = "Python"},
            //    new PGLanguage { LanguageName = "SQL"},
            //    new PGLanguage { LanguageName = "VisualBasic"},
            //    new PGLanguage { LanguageName = "Perl"},
            //    new PGLanguage { LanguageName = "Ruby"},
            //    new PGLanguage { LanguageName = "Lisp"},
            //    new PGLanguage { LanguageName = "Delphi"},
            //    new PGLanguage { LanguageName = "Pascal"},
            //    new PGLanguage { LanguageName = "MATLAB"},
            //    new PGLanguage { LanguageName = "COBOL"},
            //    new PGLanguage { LanguageName = "Groovy"},
            //    new PGLanguage { LanguageName = "Ada"},
            //    new PGLanguage { LanguageName = "Assembly"},
            //    new PGLanguage { LanguageName = "Bash"},
            //    new PGLanguage { LanguageName = "Haskell"},
            //    new PGLanguage { LanguageName = "ActionScript"},
            //    new PGLanguage { LanguageName = "NXT-G"},
            //    new PGLanguage { LanguageName = "Fortran"},
            //    new PGLanguage { LanguageName = "ColdFusion"}
            //};
            //prolanguage.ForEach(s => context.PGLanguages.AddOrUpdate( x => x.LanguageName, s));

            //try
            //{
            //    context.SaveChanges();
            //}
            //catch (System.Data.Entity.Validation.DbEntityValidationException e)
            //{
            //    var outputLines = new List<string>();
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        outputLines.Add(string.Format(
            //            "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
            //            DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            outputLines.Add(string.Format(
            //                "- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage));
            //        }
            //    }
            //    //Error text file path: CSEmployerMVC\Migrations\errors.txt
            //    System.IO.File.AppendAllLines(@"C:\Temp\errors.txt", outputLines);
            //    throw;
            //}

            //var jobs = new List<Job>
            //{
            //    new Job {JobTitle="Software Engineer", Department="Office", Recruiter="Steve Ballmer", Location="Redmond, WA", PositionType="Full-Time", HoursPerWeek=40 , Salary=105000.00, PayRate= Rate.Year , 
            //                reqDegree=Degrees.Masters , reqYearsExp=5, reqPGLanguages="C# C C++", DatePosted=DateTime.Parse("2014-03-05"), EmployerID = 10},
            //    new Job {JobTitle="Jr Programmer", Department="Site", Recruiter="Rebecca Hill", Location="Seatle, WA", PositionType="Full-Time", HoursPerWeek=40 , Salary=25.20, PayRate= Rate.Hour , 
            //                reqDegree=Degrees.Bachelors , reqYearsExp=1 , reqPGLanguages="C++ C# PHP SQL", DatePosted=DateTime.Parse("2014-01-22"), EmployerID = 11},
            //    new Job {JobTitle="Internship", Department="Google Apps", Recruiter="Carla Taylor", Location="Mountain View, CA", PositionType="Internship", HoursPerWeek=15, Salary=10.00, PayRate= Rate.Hour , 
            //                reqDegree=Degrees.Bachelors , reqYearsExp=2 , reqPGLanguages="C C++ Javascript", DatePosted=DateTime.Parse("2013-12-12"), EmployerID = 1},
            //    new Job {JobTitle="Web Designer", Department="Web Management", Recruiter="Peter Long", Location="Phildelphia, PA", PositionType="Temporialy", HoursPerWeek=40 , Salary=30.00, PayRate= Rate.Hour , 
            //                reqDegree=Degrees.GED, reqYearsExp=4 , reqPGLanguages="HTML Javascript PHP SQL", DatePosted=DateTime.Parse("2014-02-23"), EmployerID = 5},
            //    new Job {JobTitle="Web Developer", Department="Web Management", Recruiter="Terri Terry", Location="Dalton, OH", PositionType="Full-Time", HoursPerWeek=40 , Salary=2500.00, PayRate= Rate.BiWeek, 
            //                reqDegree=Degrees.Bachelors , reqYearsExp=5, reqPGLanguages="Javascript PHP SQL HTML CSS", DatePosted=DateTime.Parse("2014-01-01"), EmployerID = 7},
            //    new Job {JobTitle="Sr. Project Manager", Department="Development", Recruiter="Dean Thompson", Location="Houston, TX", PositionType="Full-Time", HoursPerWeek=40 , Salary=110000.00, PayRate= Rate.Year , 
            //                reqDegree=Degrees.Masters , reqYearsExp=8 , reqPGLanguages="C++ C Java", DatePosted=DateTime.Parse("2013-11-10"), EmployerID = 8},
            //    new Job {JobTitle="Developer", Department="Team 2", Recruiter="Jean DePolt", Location="Quebec, Canada", PositionType="Full-Time", HoursPerWeek=50 , Salary=28.00, PayRate= Rate.Hour , 
            //                reqDegree=Degrees.Bachelors , reqYearsExp=5 , reqPGLanguages="C++", DatePosted=DateTime.Parse("2014-03-03"), EmployerID = 6},
            //    new Job {JobTitle="Assistant Developer", Department="E-Learning", Recruiter="Don Johnson", Location="San Jose, CA", PositionType="Part-Time", HoursPerWeek=20, Salary=700.00, PayRate= Rate.Month, 
            //                reqDegree=Degrees.Certificate, reqYearsExp=2 , reqPGLanguages="C# HTML Javascript", DatePosted=DateTime.Parse("2014-03-05"), EmployerID = 12},
            //    new Job {JobTitle="Programmer I", Department="IT", Recruiter="Ben Cavel", Location="San Diego, CA", PositionType="Full-Time", HoursPerWeek=40 , Salary=6000.00, PayRate= Rate.Month, 
            //                reqDegree=Degrees.Bachelors , reqYearsExp=5, reqPGLanguages="C# Java SQL", DatePosted=DateTime.Parse("2014-03-12"), EmployerID = 5},
            //    new Job {JobTitle="Database Manager", Department="ITS", Recruiter="David Hooper", Location="Bakersfield, CA", PositionType="Full-Time", HoursPerWeek=40, Salary=2644.00, PayRate= Rate.Week , 
            //                reqDegree=Degrees.Masters , reqYearsExp=6, reqPGLanguages="SQL C# PHP", DatePosted=DateTime.Parse("2014-02-02"), EmployerID = 3},
            //    new Job {JobTitle="System Admin", Department="IT", Recruiter="Bob Harigan", Location="Las Vegas, NV", PositionType="Full-Time", HoursPerWeek=40 , Salary=2420.00, PayRate= Rate.BiWeek , 
            //                reqDegree=Degrees.Bachelors, reqYearsExp=3, reqPGLanguages="C C++ Ruby", DatePosted=DateTime.Parse("2013-10-25"), EmployerID = 4},
            //    new Job {JobTitle="Programmer I", Department="Applications", Recruiter="Sue Darcy", Location="Portland, OR", PositionType="Full-Time", HoursPerWeek=45 , Salary=27.00, PayRate= Rate.Hour , 
            //                reqDegree=Degrees.Bachelors, reqYearsExp=2, reqPGLanguages="Python C# SQL PHP", DatePosted=DateTime.Parse("2014-02-03"), EmployerID = 5},
            //    new Job {JobTitle="Robotics Engineer", Department="Drones", Recruiter="Herny Fruad", Location="Seatle, WA", PositionType="Full-Time", HoursPerWeek=40 , Salary=160000.00, PayRate= Rate.Year, 
            //                reqDegree=Degrees.Masters, reqYearsExp=6, reqPGLanguages="NXT-G C Java", DatePosted=DateTime.Parse("2013-11-09"), EmployerID = 11},
            //    new Job {JobTitle="Software Engineer", Department="Production Team 1", Recruiter="Peter Malone", Location="Atlanta, GA", PositionType="Full-Time", HoursPerWeek=40 , Salary=90000.00, PayRate= Rate.Year, 
            //                reqDegree=Degrees.Masters , reqYearsExp=5 , reqPGLanguages="C C++ Assembly", DatePosted=DateTime.Parse("2013-02-15"), EmployerID = 10},
            //    new Job {JobTitle="Assistant Programmer", Department="Tech Support", Recruiter="Janice Henning", Location="Santa Clarita, CA", PositionType="Part-Time", HoursPerWeek=25 , Salary=750.00, PayRate= Rate.BiWeek, 
            //                reqDegree=Degrees.Certificate , reqYearsExp=3 , reqPGLanguages="C# HTML Javascript Python", DatePosted=DateTime.Parse("2014-01-19"), EmployerID = 12},
            //    new Job {JobTitle="Programmer", Department="IT", Recruiter="Leroy Newberry", Location="Charlotte, NC", PositionType="Temporialy", HoursPerWeek=40 , Salary=1024.00, PayRate= Rate.Week, 
            //                reqDegree=Degrees.Masters , reqYearsExp=5, reqPGLanguages="HTML PHP SQL Javascript C#", DatePosted=DateTime.Parse("2014-03-05"), EmployerID = 9}
            //};
            //jobs.ForEach(s => context.Jobs.AddOrUpdate(x => x.JobTitle, s));

            //try
            //{
            //    context.SaveChanges();
            //}
            //catch (System.Data.Entity.Validation.DbEntityValidationException e)
            //{
            //    var outputLines = new List<string>();
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        outputLines.Add(string.Format(
            //            "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
            //            DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            outputLines.Add(string.Format(
            //                "- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage));
            //        }
            //    }
            //    //Error text file path: CSEmployerMVC\Migrations\errors.txt
            //    System.IO.File.AppendAllLines(@"C:\Temp\errors.txt", outputLines);
            //    throw;
            //}

        }


    }
}
