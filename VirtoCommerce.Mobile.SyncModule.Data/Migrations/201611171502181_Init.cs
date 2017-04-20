namespace VirtoCommerce.Mobile.SyncModule.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MobileSettings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ProductsCategoryId = c.String(),
                        AccountId = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MobileSettings");
        }
    }
}
