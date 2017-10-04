namespace CarModsHeaven.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameprojectpropertyshortStorytoModificationsList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ModificationsList", c => c.String(nullable: false));
            DropColumn("dbo.Projects", "ShortStory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "ShortStory", c => c.String(nullable: false));
            DropColumn("dbo.Projects", "ModificationsList");
        }
    }
}
