namespace BanglaBazarFoodCourt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployeeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        SIN = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Wage = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.SIN);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
