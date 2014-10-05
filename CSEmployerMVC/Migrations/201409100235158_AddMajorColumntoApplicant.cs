namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMajorColumntoApplicant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applicants", "Major", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applicants", "Major");
        }
    }
}
