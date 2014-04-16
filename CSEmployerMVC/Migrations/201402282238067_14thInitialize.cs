namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14thInitialize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "PositionType", c => c.String());
            AddColumn("dbo.Jobs", "HoursPerWeek", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "HoursPerWeek");
            DropColumn("dbo.Jobs", "PositionType");
        }
    }
}
