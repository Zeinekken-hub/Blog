namespace BlogMvcApp.DLL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QustionnaireLanguage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questionnaires", "Language", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questionnaires", "Language");
        }
    }
}
