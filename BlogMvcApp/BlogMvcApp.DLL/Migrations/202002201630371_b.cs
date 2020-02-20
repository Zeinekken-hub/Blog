namespace BlogMvcApp.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Articles", "ApplicationUserId");
            DropColumn("dbo.Feedbacks", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Feedbacks", "ApplicationUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Articles", "ApplicationUserId", c => c.Int(nullable: false));
        }
    }
}
