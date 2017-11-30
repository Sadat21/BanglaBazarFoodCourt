namespace BanglaBazarFoodCourt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFood_ItemTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Food_Item",
                c => new
                    {
                        FoodID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Availability = c.Int(nullable: false),
                        Type = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Picture = c.Binary(),
                    })
                .PrimaryKey(t => t.FoodID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Food_Item");
        }
    }
}
