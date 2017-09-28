namespace CarModsHeaven.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedprojectdatamodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Projects", new[] { "IsDeleted" });
            DropTable("dbo.Projects");
        }
    }
}
