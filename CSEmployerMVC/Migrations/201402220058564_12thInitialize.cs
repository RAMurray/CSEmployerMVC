namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12thInitialize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "PayRate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "PayRate");
        }
    }
}
