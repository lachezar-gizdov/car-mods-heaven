namespace CarModsHeaven.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddMadeByPropToProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "MadeBy", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "MadeBy");
        }
    }
}
