namespace GabsWinformEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastlogin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "LastLogin", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "LastLogin");
        }
    }
}
