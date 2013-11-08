namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2ndInitialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resumes",
                c => new
                    {
                        ApplicantID = c.Int(nullable: false),
                        FileData = c.Binary(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.ApplicantID)
                .ForeignKey("dbo.Applicants", t => t.ApplicantID)
                .Index(t => t.ApplicantID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Resumes", new[] { "ApplicantID" });
            DropForeignKey("dbo.Resumes", "ApplicantID", "dbo.Applicants");
            DropTable("dbo.Resumes");
        }
    }
}
