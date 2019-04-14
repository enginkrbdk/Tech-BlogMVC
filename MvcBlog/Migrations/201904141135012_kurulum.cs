namespace MvcBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kurulum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        ImageUrl = c.String(),
                        Date = c.DateTime(nullable: false),
                        Category_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Date = c.DateTime(nullable: false),
                        Article_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.Article_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Article_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FullName = c.String(),
                        PhotoUrl = c.String(),
                        Mail = c.String(),
                        Authorization = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagArticles",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Article_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Article_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Articles", t => t.Article_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Article_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagArticles", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.TagArticles", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Articles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.Articles", "Category_Id", "dbo.Categories");
            DropIndex("dbo.TagArticles", new[] { "Article_Id" });
            DropIndex("dbo.TagArticles", new[] { "Tag_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "Article_Id" });
            DropIndex("dbo.Articles", new[] { "User_Id" });
            DropIndex("dbo.Articles", new[] { "Category_Id" });
            DropTable("dbo.TagArticles");
            DropTable("dbo.Tags");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            DropTable("dbo.Articles");
        }
    }
}
