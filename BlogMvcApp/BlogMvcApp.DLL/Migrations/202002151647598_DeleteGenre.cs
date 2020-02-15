namespace BlogMvcApp.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteGenre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "GenreId", "dbo.Genres");
            DropIndex("dbo.Articles", new[] { "GenreId" });
            DropColumn("dbo.Articles", "GenreId");
            DropTable("dbo.Genres");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Mood = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Articles", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "GenreId");
            AddForeignKey("dbo.Articles", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
