namespace bargainBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemiSelBuy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SellBuys", "Remain", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SellBuys", "Remain");
        }
    }
}
