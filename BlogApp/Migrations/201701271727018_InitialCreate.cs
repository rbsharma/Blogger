namespace BlogApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblComment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PublishedAt = c.DateTime(nullable: false),
                        Post_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblPost", t => t.Post_Id)
                .ForeignKey("dbo.tblUser", t => t.User_Id)
                .Index(t => t.Post_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.tblPost",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        PublishedAt = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblUser", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.tblTag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Famous = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblPostTags",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostId, t.TagId })
                .ForeignKey("dbo.tblPost", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.tblTag", t => t.TagId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblPost", "User_Id", "dbo.tblUser");
            DropForeignKey("dbo.tblComment", "User_Id", "dbo.tblUser");
            DropForeignKey("dbo.tblPostTags", "TagId", "dbo.tblTag");
            DropForeignKey("dbo.tblPostTags", "PostId", "dbo.tblPost");
            DropForeignKey("dbo.tblComment", "Post_Id", "dbo.tblPost");
            DropIndex("dbo.tblPostTags", new[] { "TagId" });
            DropIndex("dbo.tblPostTags", new[] { "PostId" });
            DropIndex("dbo.tblPost", new[] { "User_Id" });
            DropIndex("dbo.tblComment", new[] { "User_Id" });
            DropIndex("dbo.tblComment", new[] { "Post_Id" });
            DropTable("dbo.tblPostTags");
            DropTable("dbo.tblUser");
            DropTable("dbo.tblTag");
            DropTable("dbo.tblPost");
            DropTable("dbo.tblComment");
        }
    }
}
