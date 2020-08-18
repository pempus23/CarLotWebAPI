namespace AutoLotDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "CarId", "dbo.Inventories");
            DropForeignKey("dbo.Orders", "Customerld", "dbo.Customers");
            DropIndex("dbo.CreditRisks", "IDX_CreditRisk_Name");
            DropIndex("dbo.Orders", new[] { "CarId" });
            DropIndex("dbo.Orders", new[] { "Customerld" });
            DropTable("dbo.CreditRisks");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.Inventories");
        }
    }
}
