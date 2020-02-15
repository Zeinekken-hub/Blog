namespace BlogMvcApp.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTagColor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "Color", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tags", "Color");
        }
    }
}
