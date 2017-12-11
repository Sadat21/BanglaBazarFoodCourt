namespace BanglaBazarFoodCourt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedsomevalidationtoPromo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Promoes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Promoes", "Description", c => c.String(maxLength: 160));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Promoes", "Description", c => c.String());
            AlterColumn("dbo.Promoes", "Name", c => c.String());
        }
    }
}
