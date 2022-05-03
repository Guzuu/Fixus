namespace Fixus.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class post : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 300),
                        AddedByUser_UserId = c.Int(nullable: false),
                        AssignedToUser_UserId = c.Int(),
                        Category_CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.User", t => t.AddedByUser_UserId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.AssignedToUser_UserId)
                .ForeignKey("dbo.Category", t => t.Category_CategoryId, cascadeDelete: true)
                .Index(t => t.AddedByUser_UserId)
                .Index(t => t.AssignedToUser_UserId)
                .Index(t => t.Category_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "Category_CategoryId", "dbo.Category");
            DropForeignKey("dbo.Post", "AssignedToUser_UserId", "dbo.User");
            DropForeignKey("dbo.Post", "AddedByUser_UserId", "dbo.User");
            DropIndex("dbo.Post", new[] { "Category_CategoryId" });
            DropIndex("dbo.Post", new[] { "AssignedToUser_UserId" });
            DropIndex("dbo.Post", new[] { "AddedByUser_UserId" });
            DropTable("dbo.Post");
        }
    }
}
