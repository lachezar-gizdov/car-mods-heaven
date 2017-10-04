namespace CarModsHeaven.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RenameprojectpropertyshortStorytoModificationsList : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Projects", "ModificationsList", c => c.String(nullable: false));
            this.DropColumn("dbo.Projects", "ShortStory");
        }
        
        public override void Down()
        {
            this.AddColumn("dbo.Projects", "ShortStory", c => c.String(nullable: false));
            this.DropColumn("dbo.Projects", "ModificationsList");
        }
    }
}
