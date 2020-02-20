namespace BlogMvcApp.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserToArticleToFeedback : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "ClientProfileId", c => c.Int(nullable: false));
            AddColumn("dbo.Articles", "ClientProfile_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Feedbacks", "ClientProfileId", c => c.Int(nullable: false));
            AddColumn("dbo.Feedbacks", "ClientProfile_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Articles", "ClientProfile_Id");
            CreateIndex("dbo.Feedbacks", "ClientProfile_Id");
            AddForeignKey("dbo.Articles", "ClientProfile_Id", "dbo.ClientProfiles", "Id");
            AddForeignKey("dbo.Feedbacks", "ClientProfile_Id", "dbo.ClientProfiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "ClientProfile_Id", "dbo.ClientProfiles");
            DropForeignKey("dbo.Articles", "ClientProfile_Id", "dbo.ClientProfiles");
            DropIndex("dbo.Feedbacks", new[] { "ClientProfile_Id" });
            DropIndex("dbo.Articles", new[] { "ClientProfile_Id" });
            DropColumn("dbo.Feedbacks", "ClientProfile_Id");
            DropColumn("dbo.Feedbacks", "ClientProfileId");
            DropColumn("dbo.Articles", "ClientProfile_Id");
            DropColumn("dbo.Articles", "ClientProfileId");
        }
    }
}
