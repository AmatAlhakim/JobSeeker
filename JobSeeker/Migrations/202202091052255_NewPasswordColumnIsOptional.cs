namespace JobSeeker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPasswordColumnIsOptional : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EditProfileViewModels", "NewPassword", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EditProfileViewModels", "NewPassword", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
