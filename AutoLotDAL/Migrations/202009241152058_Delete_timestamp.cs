namespace AutoLotDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete_timestamp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Inventory", "Timestamp");
            DropColumn("dbo.Orders", "Timestamp");
            DropColumn("dbo.Customers", "Timestamp");
            DropColumn("dbo.CreditRisks", "Timestamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CreditRisks", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Customers", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Orders", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Inventory", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
    }
}
