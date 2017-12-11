namespace BanglaBazarFoodCourt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MAdepicturearequiredattributeforFood_Item : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Food_Item", "Picture", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Food_Item", "Picture", c => c.Binary());
        }
    }
}
