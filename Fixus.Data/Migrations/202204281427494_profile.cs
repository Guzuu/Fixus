namespace Fixus.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(maxLength: 1),
                        Description = c.String(maxLength: 200),
                        IsRepairman = c.Boolean(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProfileId)
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profile", "User_UserId", "dbo.User");
            DropIndex("dbo.Profile", new[] { "User_UserId" });
            DropTable("dbo.Profile");
        }
    }
}
