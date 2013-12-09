namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7thInitialize : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applicants", "List_JobID", "dbo.Lists");
            DropForeignKey("dbo.Lists", "JobID", "dbo.Jobs");
            DropIndex("dbo.Applicants", new[] { "List_JobID" });
            DropIndex("dbo.Lists", new[] { "JobID" });
            AddColumn("dbo.Applicants", "Job_ID", c => c.Int());
            AddColumn("dbo.Applicants", "Job_ID1", c => c.Int());
            AddColumn("dbo.Jobs", "Candidates", c => c.String());
            AddColumn("dbo.Jobs", "Applicant_ID", c => c.Int());
            AddForeignKey("dbo.Applicants", "Job_ID", "dbo.Jobs", "ID");
            AddForeignKey("dbo.Applicants", "Job_ID1", "dbo.Jobs", "ID");
            AddForeignKey("dbo.Jobs", "Applicant_ID", "dbo.Applicants", "ID");
            CreateIndex("dbo.Applicants", "Job_ID");
            CreateIndex("dbo.Applicants", "Job_ID1");
            CreateIndex("dbo.Jobs", "Applicant_ID");
            DropColumn("dbo.Applicants", "List_JobID");
            DropTable("dbo.Lists");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        JobID = c.Int(nullable: false),
                        ListName = c.String(),
                        SavedApplicantsList = c.String(),
                    })
                .PrimaryKey(t => t.JobID);
            
            AddColumn("dbo.Applicants", "List_JobID", c => c.Int());
            DropIndex("dbo.Jobs", new[] { "Applicant_ID" });
            DropIndex("dbo.Applicants", new[] { "Job_ID1" });
            DropIndex("dbo.Applicants", new[] { "Job_ID" });
            DropForeignKey("dbo.Jobs", "Applicant_ID", "dbo.Applicants");
            DropForeignKey("dbo.Applicants", "Job_ID1", "dbo.Jobs");
            DropForeignKey("dbo.Applicants", "Job_ID", "dbo.Jobs");
            DropColumn("dbo.Jobs", "Applicant_ID");
            DropColumn("dbo.Jobs", "Candidates");
            DropColumn("dbo.Applicants", "Job_ID1");
            DropColumn("dbo.Applicants", "Job_ID");
            CreateIndex("dbo.Lists", "JobID");
            CreateIndex("dbo.Applicants", "List_JobID");
            AddForeignKey("dbo.Lists", "JobID", "dbo.Jobs", "ID");
            AddForeignKey("dbo.Applicants", "List_JobID", "dbo.Lists", "JobID");
        }
    }
}
