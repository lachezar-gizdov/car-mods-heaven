namespace CarModsHeaven.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateprojectmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Score", c => c.Double(nullable: false));
            DropColumn("dbo.Projects", "Score_Sum");
            DropColumn("dbo.Projects", "Score_VotersCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "Score_VotersCount", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "Score_Sum", c => c.Int(nullable: false));
            DropColumn("dbo.Projects", "Score");
        }
    }
}
