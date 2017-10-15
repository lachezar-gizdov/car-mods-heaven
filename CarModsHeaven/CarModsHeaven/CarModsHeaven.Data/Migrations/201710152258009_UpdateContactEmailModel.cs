namespace CarModsHeaven.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateContactEmailModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactEmails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SenderName = c.String(),
                        SenderEmail = c.String(),
                        Subject = c.String(),
                        Content = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(),
                        ModifiedOn = c.DateTime(),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ContactEmails", new[] { "IsDeleted" });
            DropTable("dbo.ContactEmails");
        }
    }
}
