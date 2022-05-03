namespace Fixus.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "ParentCategory_CategoryId", "dbo.Category");
            DropIndex("dbo.Category", new[] { "ParentCategory_CategoryId" });
            AddColumn("dbo.Category", "ParentCategoryId", c => c.Int(nullable: false));
            DropColumn("dbo.Category", "ParentCategory_CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "ParentCategory_CategoryId", c => c.Int());
            DropColumn("dbo.Category", "ParentCategoryId");
            CreateIndex("dbo.Category", "ParentCategory_CategoryId");
            AddForeignKey("dbo.Category", "ParentCategory_CategoryId", "dbo.Category", "CategoryId");
        }
    }
}
