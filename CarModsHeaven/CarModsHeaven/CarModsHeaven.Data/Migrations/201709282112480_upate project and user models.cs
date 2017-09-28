namespace CarModsHeaven.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upateprojectandusermodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Title", c => c.String());
            AddColumn("dbo.Projects", "CarBrand", c => c.String());
            AddColumn("dbo.Projects", "CarModel", c => c.String());
            AddColumn("dbo.Projects", "CarYear", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "ShortStory", c => c.String());
            AddColumn("dbo.Projects", "Owner_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "DeletedOn", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "ModifiedOn", c => c.DateTime());
            CreateIndex("dbo.Projects", "Owner_Id");
            CreateIndex("dbo.AspNetUsers", "IsDeleted");
            AddForeignKey("dbo.Projects", "Owner_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Owner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "IsDeleted" });
            DropIndex("dbo.Projects", new[] { "Owner_Id" });
            DropColumn("dbo.AspNetUsers", "ModifiedOn");
            DropColumn("dbo.AspNetUsers", "CreatedOn");
            DropColumn("dbo.AspNetUsers", "DeletedOn");
            DropColumn("dbo.AspNetUsers", "IsDeleted");
            DropColumn("dbo.Projects", "Owner_Id");
            DropColumn("dbo.Projects", "ShortStory");
            DropColumn("dbo.Projects", "CarYear");
            DropColumn("dbo.Projects", "CarModel");
            DropColumn("dbo.Projects", "CarBrand");
            DropColumn("dbo.Projects", "Title");
        }
    }
}
