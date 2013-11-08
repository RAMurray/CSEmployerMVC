namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1stInitialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false),
                        LName = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Address = c.String(maxLength: 30),
                        Zip = c.String(maxLength: 10),
                        City = c.String(nullable: false, maxLength: 30),
                        State = c.String(maxLength: 2),
                        Country = c.String(nullable: false, maxLength: 30),
                        Email = c.String(maxLength: 30),
                        Phone = c.String(maxLength: 16),
                        Fax = c.String(maxLength: 16),
                        Degree = c.String(nullable: false),
                        YearsExp = c.Int(nullable: false),
                        KnownPL1 = c.String(),
                        KnownPL2 = c.String(),
                        KnownPL3 = c.String(),
                        KnownPL4 = c.String(),
                        KnownPL5 = c.String(),
                        List_JobID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Lists", t => t.List_JobID)
                .Index(t => t.List_JobID);
            
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        JobID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobID)
                .ForeignKey("dbo.Jobs", t => t.JobID)
                .Index(t => t.JobID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(nullable: false),
                        Department = c.String(nullable: false),
                        Recruiter = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        EmployerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employers", t => t.EmployerID, cascadeDelete: true)
                .Index(t => t.EmployerID);
            
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        Address = c.String(maxLength: 30),
                        Zip = c.String(maxLength: 10),
                        City = c.String(nullable: false, maxLength: 30),
                        State = c.String(nullable: false, maxLength: 2),
                        Country = c.String(nullable: false, maxLength: 30),
                        Email = c.String(maxLength: 30),
                        Phone = c.String(maxLength: 16),
                        Fax = c.String(maxLength: 16),
                        eUsername = c.String(nullable: false),
                        ePassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PGLanguages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PglNameBase = c.String(),
                        ConfigId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PGLanguageApplicants",
                c => new
                    {
                        PGLanguage_ID = c.Int(nullable: false),
                        Applicant_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PGLanguage_ID, t.Applicant_ID })
                .ForeignKey("dbo.PGLanguages", t => t.PGLanguage_ID, cascadeDelete: true)
                .ForeignKey("dbo.Applicants", t => t.Applicant_ID, cascadeDelete: true)
                .Index(t => t.PGLanguage_ID)
                .Index(t => t.Applicant_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.PGLanguageApplicants", new[] { "Applicant_ID" });
            DropIndex("dbo.PGLanguageApplicants", new[] { "PGLanguage_ID" });
            DropIndex("dbo.Jobs", new[] { "EmployerID" });
            DropIndex("dbo.Lists", new[] { "JobID" });
            DropIndex("dbo.Applicants", new[] { "List_JobID" });
            DropForeignKey("dbo.PGLanguageApplicants", "Applicant_ID", "dbo.Applicants");
            DropForeignKey("dbo.PGLanguageApplicants", "PGLanguage_ID", "dbo.PGLanguages");
            DropForeignKey("dbo.Jobs", "EmployerID", "dbo.Employers");
            DropForeignKey("dbo.Lists", "JobID", "dbo.Jobs");
            DropForeignKey("dbo.Applicants", "List_JobID", "dbo.Lists");
            DropTable("dbo.PGLanguageApplicants");
            DropTable("dbo.PGLanguages");
            DropTable("dbo.Employers");
            DropTable("dbo.Jobs");
            DropTable("dbo.Lists");
            DropTable("dbo.Applicants");
        }
    }
}
