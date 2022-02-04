namespace JobSeeker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicationTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "PublisherId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "PublisherId");
        }
    }
}
