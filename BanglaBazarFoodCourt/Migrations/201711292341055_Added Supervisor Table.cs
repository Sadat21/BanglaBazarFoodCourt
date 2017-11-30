namespace BanglaBazarFoodCourt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSupervisorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Supervisors",
                c => new
                    {
                        SIN = c.Int(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.SIN)
                .ForeignKey("dbo.Employees", t => t.SIN)
                .Index(t => t.SIN);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Supervisors", "SIN", "dbo.Employees");
            DropIndex("dbo.Supervisors", new[] { "SIN" });
            DropTable("dbo.Supervisors");
        }
    }
}
