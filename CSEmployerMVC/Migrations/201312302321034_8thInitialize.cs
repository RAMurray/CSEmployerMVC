namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8thInitialize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PGLanguages", "LanguageName", c => c.String());
            DropColumn("dbo.PGLanguages", "PglNameBase");
            DropColumn("dbo.PGLanguages", "ConfigId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PGLanguages", "ConfigId", c => c.Int(nullable: false));
            AddColumn("dbo.PGLanguages", "PglNameBase", c => c.String());
            DropColumn("dbo.PGLanguages", "LanguageName");
        }
    }
}
