namespace CSEmployerMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                 "dbo.Applicant",
                 c => new
                 {
                     ID = c.Int(nullable: false, identity: true),
                     FName = c.String(nullable: false),
                     LName = c.String(nullable: false),
                     DOB = c.DateTime(nullable: false),
                     City = c.String(nullable: false, maxLength: 20),
                     State = c.String(nullable: false, maxLength: 2),
                     Email = c.String(nullable: true, maxLength: 20),
                     Phone = c.String(nullable: true, maxLength: 16),
                     JobTitle = c.String(nullable: false),
                     Degree = c.String(nullable: false),
                     YearsExp = c.Int(nullable: false),
                     Languages = c.String(nullable: false)
                 })
                 .PrimaryKey(t => t.ID);
        }

        public override void Down()
        {
            DropTable("dbo.Applicant");
        }
    }
}
