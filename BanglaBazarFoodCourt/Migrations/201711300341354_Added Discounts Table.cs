namespace BanglaBazarFoodCourt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDiscountsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        PromoID = c.Int(nullable: false),
                        FoodID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PromoID, t.FoodID })
                .ForeignKey("dbo.Food_Item", t => t.FoodID, cascadeDelete: true)
                .ForeignKey("dbo.Promoes", t => t.PromoID, cascadeDelete: true)
                .Index(t => t.PromoID)
                .Index(t => t.FoodID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Discounts", "PromoID", "dbo.Promoes");
            DropForeignKey("dbo.Discounts", "FoodID", "dbo.Food_Item");
            DropIndex("dbo.Discounts", new[] { "FoodID" });
            DropIndex("dbo.Discounts", new[] { "PromoID" });
            DropTable("dbo.Discounts");
        }
    }
}
