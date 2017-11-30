namespace BanglaBazarFoodCourt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPromoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Promoes",
                c => new
                    {
                        PromoID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Discount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PromoID);
           
        }
        
        public override void Down()
        {

            DropTable("dbo.Promoes");

        }
    }
}
