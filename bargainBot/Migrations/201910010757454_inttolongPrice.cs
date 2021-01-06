namespace bargainBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inttolongPrice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserBargains", "PriceGarranty", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserBargains", "PriceGarranty", c => c.Int(nullable: false));
        }
    }
}
