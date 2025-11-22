namespace HotelManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels_01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceTypes", "UpdatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Username", c => c.String());
            AddColumn("dbo.Users", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "Role", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Role", c => c.String());
            DropColumn("dbo.Users", "UpdatedAt");
            DropColumn("dbo.Users", "Username");
            DropColumn("dbo.ServiceTypes", "UpdatedAt");
        }
    }
}
