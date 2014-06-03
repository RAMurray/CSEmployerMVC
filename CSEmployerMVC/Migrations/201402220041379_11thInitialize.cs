namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11thInitialize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Salary", c => c.Double(nullable: false));
            AddColumn("dbo.Jobs", "reqDegree", c => c.Int(nullable: false));
            AddColumn("dbo.Jobs", "reqYearsExp", c => c.Int(nullable: false));
            AddColumn("dbo.Jobs", "DatePosted", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "DatePosted");
            DropColumn("dbo.Jobs", "reqYearsExp");
            DropColumn("dbo.Jobs", "reqDegree");
            DropColumn("dbo.Jobs", "Salary");
        }
    }
}
