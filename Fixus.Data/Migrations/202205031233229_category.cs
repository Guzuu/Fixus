namespace Fixus.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class category : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ParentCategory_CategoryId = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Category", t => t.ParentCategory_CategoryId)
                .Index(t => t.ParentCategory_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Category", "ParentCategory_CategoryId", "dbo.Category");
            DropIndex("dbo.Category", new[] { "ParentCategory_CategoryId" });
            DropTable("dbo.Category");
        }
    }
}
