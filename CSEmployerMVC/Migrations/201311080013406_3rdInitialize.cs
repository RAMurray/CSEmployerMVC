namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3rdInitialize : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applicants", "Degree", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Applicants", "Degree", c => c.String(nullable: false));
        }
    }
}
