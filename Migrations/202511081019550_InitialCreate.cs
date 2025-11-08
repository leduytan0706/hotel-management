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
                        CustomerId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
                        CancelDate = c.DateTime(nullable: false),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        Customer_CustomerId = c.Int(),
                        Customer_CustomerId1 = c.Int(),
                        Invoice_InvoiceId = c.Int(),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId1)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceId)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.Customer_CustomerId1)
                .Index(t => t.Invoice_InvoiceId);
            
            CreateTable(
                "dbo.BookingServices",
                c => new
                    {
                        BookingServiceId = c.Int(nullable: false, identity: true),
                        BookingId = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                    })
                .PrimaryKey(t => t.ServiceId);
            
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
                        Booking_BookingId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Bookings", t => t.Booking_BookingId)
                .Index(t => t.Booking_BookingId);
            
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
                        PaidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomNumber = c.String(),
                        RoomTypeId = c.Int(nullable: false),
                        Status = c.String(),
                        Description = c.String(),
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
                    })
                .PrimaryKey(t => t.RoomTypeId);
            
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        ServiceTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ServiceTypeId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        PasswordHash = c.String(),
                        FullName = c.String(),
                        Gender = c.String(),
                        Phone = c.String(),
                        Role = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Address = c.String(),
                        Email = c.String(),
                        IdNumber = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.Bookings", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Bookings", "Invoice_InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Bookings", "Customer_CustomerId1", "dbo.Customers");
            DropForeignKey("dbo.Bookings", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Booking_BookingId", "dbo.Bookings");
            DropForeignKey("dbo.BookingServices", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.BookingServices", "BookingId", "dbo.Bookings");
            DropIndex("dbo.Rooms", new[] { "RoomTypeId" });
            DropIndex("dbo.Customers", new[] { "Booking_BookingId" });
            DropIndex("dbo.BookingServices", new[] { "ServiceId" });
            DropIndex("dbo.BookingServices", new[] { "BookingId" });
            DropIndex("dbo.Bookings", new[] { "Invoice_InvoiceId" });
            DropIndex("dbo.Bookings", new[] { "Customer_CustomerId1" });
            DropIndex("dbo.Bookings", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Bookings", new[] { "RoomId" });
            DropTable("dbo.Users");
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.RoomTypes");
            DropTable("dbo.Rooms");
            DropTable("dbo.Invoices");
            DropTable("dbo.Customers");
            DropTable("dbo.Services");
            DropTable("dbo.BookingServices");
            DropTable("dbo.Bookings");
        }
    }
}
