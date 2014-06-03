namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4thInitialize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resumes", "Content", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resumes", "Content");
        }
    }
}
