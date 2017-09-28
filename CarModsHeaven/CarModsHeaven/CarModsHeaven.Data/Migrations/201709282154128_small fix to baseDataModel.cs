namespace CarModsHeaven.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smallfixtobaseDataModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "CreatedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
