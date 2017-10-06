namespace CarModsHeaven.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatescorepropinprojectmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Score_Sum", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "Score_VotersCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Score_VotersCount");
            DropColumn("dbo.Projects", "Score_Sum");
        }
    }
}
