namespace MvcMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Languages = c.String(nullable: false),
                        YearsExp = c.Int(nullable: false),
                        Degree = c.String(nullable: false),
                        State = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Applicants");
        }
    }
}
