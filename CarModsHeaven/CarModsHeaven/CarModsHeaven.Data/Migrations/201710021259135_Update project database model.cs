namespace CarModsHeaven.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updateprojectdatabasemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ModificationsType", c => c.Int(nullable: false));
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "CarBrand", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "CarModel", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "ShortStory", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "ShortStory", c => c.String());
            AlterColumn("dbo.Projects", "CarModel", c => c.String());
            AlterColumn("dbo.Projects", "CarBrand", c => c.String());
            AlterColumn("dbo.Projects", "Title", c => c.String());
            DropColumn("dbo.Projects", "ModificationsType");
        }
    }
}
