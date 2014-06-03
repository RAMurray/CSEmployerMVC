namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _15thInitialize : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applicants", "Address", c => c.String(maxLength: 50));
            AlterColumn("dbo.Employers", "Address", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employers", "Address", c => c.String(maxLength: 30));
            AlterColumn("dbo.Applicants", "Address", c => c.String(maxLength: 30));
        }
    }
}
