namespace JobSeeker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCategoryColumnsNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false));
            DropColumn("dbo.Categories", "category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "category", c => c.String(nullable: false));
            DropColumn("dbo.Categories", "CategoryName");
        }
    }
}
