namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22ndintilization : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resumes", "SchoolName", c => c.String());
            AddColumn("dbo.Resumes", "DegreeEarned", c => c.String());
            AddColumn("dbo.Resumes", "SchoolStayLength", c => c.String());
            AddColumn("dbo.Resumes", "LastEmployer", c => c.String());
            AddColumn("dbo.Resumes", "LastJobTitle", c => c.String());
            AddColumn("dbo.Resumes", "LastJobLength", c => c.String());
            AddColumn("dbo.Resumes", "PreviousJobDuties", c => c.String());
            DropColumn("dbo.Resumes", "ContentEducation");
            DropColumn("dbo.Resumes", "ContentPastJobs");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resumes", "ContentPastJobs", c => c.String());
            AddColumn("dbo.Resumes", "ContentEducation", c => c.String());
            DropColumn("dbo.Resumes", "PreviousJobDuties");
            DropColumn("dbo.Resumes", "LastJobLength");
            DropColumn("dbo.Resumes", "LastJobTitle");
            DropColumn("dbo.Resumes", "LastEmployer");
            DropColumn("dbo.Resumes", "SchoolStayLength");
            DropColumn("dbo.Resumes", "DegreeEarned");
            DropColumn("dbo.Resumes", "SchoolName");
        }
    }
}
