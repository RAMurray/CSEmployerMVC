namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _9thInitialize : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resumes", "ApplicantID", "dbo.Applicants");
            DropIndex("dbo.Resumes", new[] { "ApplicantID" });
            AddColumn("dbo.Applicants", "Resume", c => c.Binary());
            AddColumn("dbo.Applicants", "FileMimeType", c => c.String());
            DropTable("dbo.Resumes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Resumes",
                c => new
                    {
                        ApplicantID = c.Int(nullable: false),
                        FileData = c.Binary(),
                        Content = c.String(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.ApplicantID);
            
            DropColumn("dbo.Applicants", "FileMimeType");
            DropColumn("dbo.Applicants", "Resume");
            CreateIndex("dbo.Resumes", "ApplicantID");
            AddForeignKey("dbo.Resumes", "ApplicantID", "dbo.Applicants", "ID");
        }
    }
}
