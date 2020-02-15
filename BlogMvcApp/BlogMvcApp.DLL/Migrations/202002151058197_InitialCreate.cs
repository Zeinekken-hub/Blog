namespace BlogMvcApp.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Text = c.String(nullable: false),
                        Mark = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Mood = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questionnaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        IsAlone = c.Boolean(nullable: false),
                        IsStable = c.Boolean(nullable: false),
                        Language = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArticleTags",
                c => new
                    {
                        Article_Id = c.Int(nullable: false),
                        Tag_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Article_Id, t.Tag_Id })
                .ForeignKey("dbo.Articles", t => t.Article_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .Index(t => t.Article_Id)
                .Index(t => t.Tag_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArticleTags", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.ArticleTags", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.Articles", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Feedbacks", "ArticleId", "dbo.Articles");
            DropIndex("dbo.ArticleTags", new[] { "Tag_Id" });
            DropIndex("dbo.ArticleTags", new[] { "Article_Id" });
            DropIndex("dbo.Feedbacks", new[] { "ArticleId" });
            DropIndex("dbo.Articles", new[] { "GenreId" });
            DropTable("dbo.ArticleTags");
            DropTable("dbo.Questionnaires");
            DropTable("dbo.Tags");
            DropTable("dbo.Genres");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Articles");
        }
    }
}
