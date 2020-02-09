namespace BlogMvcApp.DLL.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Text = c.String(),
                    Author = c.String(),
                    Date = c.DateTime(nullable: false),
                    IsDeleted = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Feedbacks",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Author = c.String(),
                    Date = c.DateTime(nullable: false),
                    Text = c.String(),
                    Mark = c.Int(nullable: false),
                    ArticleId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "ArticleId", "dbo.Articles");
            DropIndex("dbo.Feedbacks", new[] { "ArticleId" });
            DropTable("dbo.Feedbacks");
            DropTable("dbo.Articles");
        }
    }
}