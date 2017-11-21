namespace BanglaBazarFoodCourt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Customer_Table2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "name", c => c.String());
            AddColumn("dbo.Customers", "contactNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "contactNo");
            DropColumn("dbo.Customers", "name");
        }
    }
}
