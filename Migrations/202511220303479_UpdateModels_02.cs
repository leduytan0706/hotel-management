namespace HotelManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "UpdatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "UpdatedAt");
        }
    }
}
