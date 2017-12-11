namespace BanglaBazarFoodCourt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedvalidationforalltables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Food_Item", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Food_Item", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Food_Item", "Description", c => c.String(maxLength: 160));
            AlterColumn("dbo.Orders", "orderTime", c => c.String(maxLength: 5));
            AlterColumn("dbo.Orders", "pickupTime", c => c.String(maxLength: 5));
            AlterColumn("dbo.Customers", "contactNo", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String());
            AlterColumn("dbo.Customers", "contactNo", c => c.String());
            AlterColumn("dbo.Orders", "pickupTime", c => c.String());
            AlterColumn("dbo.Orders", "orderTime", c => c.String());
            AlterColumn("dbo.Food_Item", "Description", c => c.String());
            AlterColumn("dbo.Food_Item", "Type", c => c.String());
            AlterColumn("dbo.Food_Item", "Name", c => c.String());
        }
    }
}
