namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16thInitialize : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applicants", "City", c => c.String(maxLength: 30));
            AlterColumn("dbo.Employers", "City", c => c.String(maxLength: 30));
            AlterColumn("dbo.Employers", "State", c => c.String(maxLength: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employers", "State", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.Employers", "City", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Applicants", "City", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
