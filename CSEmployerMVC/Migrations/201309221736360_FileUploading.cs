namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FileUploading : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applicants", "File", c => c.Binary());
            AddColumn("dbo.Applicants", "FileMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applicants", "FileMimeType");
            DropColumn("dbo.Applicants", "File");
        }
    }
}
