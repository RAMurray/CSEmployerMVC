namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13thInitialize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "reqPGLanguages", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "reqPGLanguages");
        }
    }
}
