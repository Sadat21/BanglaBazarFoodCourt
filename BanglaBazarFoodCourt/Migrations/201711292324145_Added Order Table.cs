namespace BanglaBazarFoodCourt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        orderNo = c.Int(nullable: false, identity: true),
                        totalPrice = c.Double(nullable: false),
                        orderTime = c.String(),
                        pickupTime = c.String(),
                        date = c.DateTime(nullable: false),
                        Customer_id = c.Int(),
                    })
                .PrimaryKey(t => t.orderNo)
                .ForeignKey("dbo.Customers", t => t.Customer_id)
                .Index(t => t.Customer_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Customer_id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Customer_id" });
            DropTable("dbo.Orders");
        }
    }
}
