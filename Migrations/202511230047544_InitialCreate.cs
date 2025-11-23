namespace HotelManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(),
                        FullName = c.String(),
                        Phone = c.String(),
                        IdNumber = c.String(),
                        RoomId = c.Int(nullable: false),
                        BookedPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BookingDate = c.DateTime(nullable: false),
                        CancelDate = c.DateTime(),
                        CheckInDate = c.DateTime(),
                        CheckOutDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.RoomId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.BookingServices",
                c => new
                    {
                        BookingServiceId = c.Int(nullable: false, identity: true),
                        BookingId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BookingServiceId)
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.BookingId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        ServiceTypeId = c.Int(nullable: false),
                        ServiceName = c.String(),
                        Description = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsAvailable = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceId)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeId, cascadeDelete: true)
                .Index(t => t.ServiceTypeId);
            
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        ServiceTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        ServiceCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceTypeId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Phone = c.String(),
                        IdNumber = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomNumber = c.String(),
                        RoomTypeId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Description = c.String(),
                        DefaultPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        MaximumCapacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.RoomTypes", t => t.RoomTypeId, cascadeDelete: true)
                .Index(t => t.RoomTypeId);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        RoomTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        BasePricePerNight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumCapacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomTypeId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        PasswordHash = c.String(),
                        FullName = c.String(),
                        Username = c.String(),
                        Gender = c.String(),
                        Phone = c.String(),
                        Role = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Address = c.String(),
                        Email = c.String(),
                        IdNumber = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        BookingId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        RoomCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ServiceCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiscountAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                        PaymentStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.BookingId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "UserId", "dbo.Users");
            DropForeignKey("dbo.Invoices", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.Bookings", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Services", "ServiceTypeId", "dbo.ServiceTypes");
            DropForeignKey("dbo.BookingServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.BookingServices", "BookingId", "dbo.Bookings");
            DropIndex("dbo.Invoices", new[] { "UserId" });
            DropIndex("dbo.Invoices", new[] { "BookingId" });
            DropIndex("dbo.Rooms", new[] { "RoomTypeId" });
            DropIndex("dbo.Services", new[] { "ServiceTypeId" });
            DropIndex("dbo.BookingServices", new[] { "ServiceId" });
            DropIndex("dbo.BookingServices", new[] { "BookingId" });
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropIndex("dbo.Bookings", new[] { "RoomId" });
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropTable("dbo.Invoices");
            DropTable("dbo.Users");
            DropTable("dbo.RoomTypes");
            DropTable("dbo.Rooms");
            DropTable("dbo.Customers");
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.Services");
            DropTable("dbo.BookingServices");
            DropTable("dbo.Bookings");
        }
    }
}
