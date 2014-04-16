namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _19thInitialize : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Applicants", "Job_ID", "dbo.Jobs");
            DropForeignKey("dbo.Applicants", "Job_ID1", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "Applicant_ID", "dbo.Applicants");
            DropIndex("dbo.Applicants", new[] { "Job_ID" });
            DropIndex("dbo.Applicants", new[] { "Job_ID1" });
            DropIndex("dbo.Jobs", new[] { "Applicant_ID" });
            CreateTable(
                "dbo.JobApplicants",
                c => new
                    {
                        Job_ID = c.Int(nullable: false),
                        Applicant_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Job_ID, t.Applicant_ID })
                .ForeignKey("dbo.Jobs", t => t.Job_ID, cascadeDelete: true)
                .ForeignKey("dbo.Applicants", t => t.Applicant_ID, cascadeDelete: true)
                .Index(t => t.Job_ID)
                .Index(t => t.Applicant_ID);
            
            DropColumn("dbo.Applicants", "Job_ID");
            DropColumn("dbo.Applicants", "Job_ID1");
            DropColumn("dbo.Jobs", "Candidates");
            DropColumn("dbo.Jobs", "Applicant_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "Applicant_ID", c => c.Int());
            AddColumn("dbo.Jobs", "Candidates", c => c.String());
            AddColumn("dbo.Applicants", "Job_ID1", c => c.Int());
            AddColumn("dbo.Applicants", "Job_ID", c => c.Int());
            DropIndex("dbo.JobApplicants", new[] { "Applicant_ID" });
            DropIndex("dbo.JobApplicants", new[] { "Job_ID" });
            DropForeignKey("dbo.JobApplicants", "Applicant_ID", "dbo.Applicants");
            DropForeignKey("dbo.JobApplicants", "Job_ID", "dbo.Jobs");
            DropTable("dbo.JobApplicants");
            CreateIndex("dbo.Jobs", "Applicant_ID");
            CreateIndex("dbo.Applicants", "Job_ID1");
            CreateIndex("dbo.Applicants", "Job_ID");
            AddForeignKey("dbo.Jobs", "Applicant_ID", "dbo.Applicants", "ID");
            AddForeignKey("dbo.Applicants", "Job_ID1", "dbo.Jobs", "ID");
            AddForeignKey("dbo.Applicants", "Job_ID", "dbo.Jobs", "ID");
        }
    }
}
