namespace GabsWinformEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserReg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(unicode: false),
                        ISBN = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(unicode: false),
                        PasswordHash = c.Binary(),
                        PasswordSalt = c.Binary(),
                        FirstName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        Phone = c.String(unicode: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Contacts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Phone = c.String(unicode: false),
                        Email = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Users");
            DropTable("dbo.Books");
        }
    }
}
