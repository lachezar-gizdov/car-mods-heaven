namespace CarModsHeaven.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RemoveUserProfileImage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "UserPhoto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserPhoto", c => c.Binary());
        }
    }
}
