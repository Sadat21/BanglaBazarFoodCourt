namespace BanglaBazarFoodCourt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedContainsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contains",
                c => new
                    {
                        OrderNo = c.Int(nullable: false),
                        FoodID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderNo, t.FoodID })
                .ForeignKey("dbo.Food_Item", t => t.FoodID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderNo, cascadeDelete: true)
                .Index(t => t.OrderNo)
                .Index(t => t.FoodID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contains", "OrderNo", "dbo.Orders");
            DropForeignKey("dbo.Contains", "FoodID", "dbo.Food_Item");
            DropIndex("dbo.Contains", new[] { "FoodID" });
            DropIndex("dbo.Contains", new[] { "OrderNo" });
            DropTable("dbo.Contains");
        }
    }
}
