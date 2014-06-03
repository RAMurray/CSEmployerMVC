namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5thInitialize : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employers", "eUsername");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employers", "eUsername", c => c.String(nullable: false));
        }
    }
}
