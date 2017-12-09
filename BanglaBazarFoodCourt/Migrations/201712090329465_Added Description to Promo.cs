namespace BanglaBazarFoodCourt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDescriptiontoPromo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promoes", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Promoes", "Description");
        }
    }
}
