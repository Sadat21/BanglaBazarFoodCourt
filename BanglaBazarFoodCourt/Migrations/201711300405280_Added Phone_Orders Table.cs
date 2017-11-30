namespace BanglaBazarFoodCourt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPhone_OrdersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Phone_Order",
                c => new
                    {
                        CustomerID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        SIN = c.Int(nullable: false),
                        OrderTime = c.DateTime(nullable: false),
                        PickupTime = c.DateTime(nullable: false),
                        PickedUp = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerID, t.OrderID, t.SIN })
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.SIN, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.OrderID)
                .Index(t => t.SIN);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phone_Order", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Phone_Order", "SIN", "dbo.Employees");
            DropForeignKey("dbo.Phone_Order", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Phone_Order", new[] { "SIN" });
            DropIndex("dbo.Phone_Order", new[] { "OrderID" });
            DropIndex("dbo.Phone_Order", new[] { "CustomerID" });
            DropTable("dbo.Phone_Order");
        }
    }
}
