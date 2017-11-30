namespace BanglaBazarFoodCourt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameParametertoPromo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promoes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Promoes", "Name");
        }
    }
}
