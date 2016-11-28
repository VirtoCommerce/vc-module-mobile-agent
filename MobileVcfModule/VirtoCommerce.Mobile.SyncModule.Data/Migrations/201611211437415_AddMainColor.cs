namespace VirtoCommerce.Mobile.SyncModule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMainColor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MobileSettings", "MainColor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MobileSettings", "MainColor");
        }
    }
}
