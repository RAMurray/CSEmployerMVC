namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6thInitialize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lists", "ListName", c => c.String());
            AddColumn("dbo.Lists", "SavedApplicantsList", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lists", "SavedApplicantsList");
            DropColumn("dbo.Lists", "ListName");
        }
    }
}
