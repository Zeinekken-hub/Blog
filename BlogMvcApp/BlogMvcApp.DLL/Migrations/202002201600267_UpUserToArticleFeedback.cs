namespace BlogMvcApp.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpUserToArticleFeedback : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "ClientProfile_Id", "dbo.ClientProfiles");
            DropForeignKey("dbo.Feedbacks", "ClientProfile_Id", "dbo.ClientProfiles");
            DropIndex("dbo.Articles", new[] { "ClientProfile_Id" });
            DropIndex("dbo.Feedbacks", new[] { "ClientProfile_Id" });
            AddColumn("dbo.Articles", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Articles", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Feedbacks", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Feedbacks", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Articles", "ApplicationUser_Id");
            CreateIndex("dbo.Feedbacks", "ApplicationUser_Id");
            AddForeignKey("dbo.Articles", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Feedbacks", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Articles", "ClientProfileId");
            DropColumn("dbo.Articles", "ClientProfile_Id");
            DropColumn("dbo.Feedbacks", "ClientProfileId");
            DropColumn("dbo.Feedbacks", "ClientProfile_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Feedbacks", "ClientProfile_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Feedbacks", "ClientProfileId", c => c.Int(nullable: false));
            AddColumn("dbo.Articles", "ClientProfile_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Articles", "ClientProfileId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Feedbacks", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Articles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Feedbacks", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Articles", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Feedbacks", "ApplicationUser_Id");
            DropColumn("dbo.Feedbacks", "ApplicationUserId");
            DropColumn("dbo.Articles", "ApplicationUser_Id");
            DropColumn("dbo.Articles", "ApplicationUserId");
            CreateIndex("dbo.Feedbacks", "ClientProfile_Id");
            CreateIndex("dbo.Articles", "ClientProfile_Id");
            AddForeignKey("dbo.Feedbacks", "ClientProfile_Id", "dbo.ClientProfiles", "Id");
            AddForeignKey("dbo.Articles", "ClientProfile_Id", "dbo.ClientProfiles", "Id");
        }
    }
}
