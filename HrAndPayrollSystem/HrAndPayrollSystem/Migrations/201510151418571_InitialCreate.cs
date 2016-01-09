namespace HrAndPayrollSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        SystemCode = c.String(nullable: false, maxLength: 10),
                        Code = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 100),
                        GroupCode = c.String(nullable: false, maxLength: 20),
                        GroupTitle = c.String(nullable: false, maxLength: 100),
                        ContactPerson = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 250),
                        ContactNumber = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.SystemCode, t.Code });
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        SystemCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserLogins");
            DropTable("dbo.Departments");
        }
    }
}
