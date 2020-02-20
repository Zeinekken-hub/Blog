namespace BlogMvcApp.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lll : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClientProfiles", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.ClientProfiles", new[] { "Id" });
            RenameColumn(table: "dbo.Articles", name: "ApplicationUser_Id", newName: "BlogUserId");
            RenameColumn(table: "dbo.Feedbacks", name: "ApplicationUser_Id", newName: "BlogUserId");
            RenameIndex(table: "dbo.Articles", name: "IX_ApplicationUser_Id", newName: "IX_BlogUserId");
            RenameIndex(table: "dbo.Feedbacks", name: "IX_ApplicationUser_Id", newName: "IX_BlogUserId");
            DropColumn("dbo.Articles", "Author");
            DropTable("dbo.ClientProfiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ClientProfiles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Articles", "Author", c => c.String(nullable: false));
            RenameIndex(table: "dbo.Feedbacks", name: "IX_BlogUserId", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.Articles", name: "IX_BlogUserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Feedbacks", name: "BlogUserId", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Articles", name: "BlogUserId", newName: "ApplicationUser_Id");
            CreateIndex("dbo.ClientProfiles", "Id");
            AddForeignKey("dbo.ClientProfiles", "Id", "dbo.AspNetUsers", "Id");
        }
    }
}
