namespace HotelManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoomPrices",
                c => new
                    {
                        RoomPriceId = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        PricePerNight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RoomPriceId)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            AddColumn("dbo.Bookings", "BookedPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.BookingServices", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Services", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Customers", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Invoices", "DiscountAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Rooms", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rooms", "DefaultPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Rooms", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rooms", "UpdatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rooms", "MaximumCapacity", c => c.Int(nullable: false));
            AddColumn("dbo.RoomTypes", "MaximumCapacity", c => c.Int(nullable: false));
            AddColumn("dbo.ServiceTypes", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Rooms", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomPrices", "RoomId", "dbo.Rooms");
            DropIndex("dbo.RoomPrices", new[] { "RoomId" });
            AlterColumn("dbo.Rooms", "Status", c => c.String());
            DropColumn("dbo.ServiceTypes", "CreatedAt");
            DropColumn("dbo.RoomTypes", "MaximumCapacity");
            DropColumn("dbo.Rooms", "MaximumCapacity");
            DropColumn("dbo.Rooms", "UpdatedAt");
            DropColumn("dbo.Rooms", "CreatedAt");
            DropColumn("dbo.Rooms", "DefaultPrice");
            DropColumn("dbo.Rooms", "IsDeleted");
            DropColumn("dbo.Invoices", "DiscountAmount");
            DropColumn("dbo.Customers", "CreatedAt");
            DropColumn("dbo.Services", "CreatedAt");
            DropColumn("dbo.BookingServices", "CreatedAt");
            DropColumn("dbo.Bookings", "BookedPrice");
            DropTable("dbo.RoomPrices");
        }
    }
}
