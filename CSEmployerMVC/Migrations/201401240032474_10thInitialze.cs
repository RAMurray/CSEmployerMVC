namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10thInitialze : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resumes",
                c => new
                    {
                        ApplicantID = c.Int(nullable: false),
                        Imported = c.Boolean(nullable: false),
                        ContentSkills = c.String(),
                        ContentEducation = c.String(),
                        ContentPastJobs = c.String(),
                    })
                .PrimaryKey(t => t.ApplicantID)
                .ForeignKey("dbo.Applicants", t => t.ApplicantID)
                .Index(t => t.ApplicantID);
            
            DropColumn("dbo.Applicants", "Resume");
            DropColumn("dbo.Applicants", "FileMimeType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applicants", "FileMimeType", c => c.String());
            AddColumn("dbo.Applicants", "Resume", c => c.Binary());
            DropIndex("dbo.Resumes", new[] { "ApplicantID" });
            DropForeignKey("dbo.Resumes", "ApplicantID", "dbo.Applicants");
            DropTable("dbo.Resumes");
        }
    }
}
