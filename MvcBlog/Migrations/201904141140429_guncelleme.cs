namespace MvcBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guncelleme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "A_Content", c => c.String());
            AddColumn("dbo.Comments", "C_Content", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "U_Authorization", c => c.Int(nullable: false));
            DropColumn("dbo.Articles", "Content");
            DropColumn("dbo.Comments", "Content");
            DropColumn("dbo.Users", "Authorization");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Authorization", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "Content", c => c.String());
            AddColumn("dbo.Articles", "Content", c => c.String());
            DropColumn("dbo.Users", "U_Authorization");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Comments", "C_Content");
            DropColumn("dbo.Articles", "A_Content");
        }
    }
}
