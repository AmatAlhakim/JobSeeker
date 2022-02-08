namespace JobSeeker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdToJobTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Jobs", "UserID");
            AddForeignKey("dbo.Jobs", "UserID", "dbo.8AspNetUsers", "Id");
            DropColumn("dbo.Jobs", "PublisherId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "PublisherId", c => c.String());
            DropForeignKey("dbo.Jobs", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Jobs", new[] { "UserID" });
            DropColumn("dbo.Jobs", "UserID");
        }
    }
}
