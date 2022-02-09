namespace JobSeeker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEditProfileModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EditProfileViewModels", "UserName", c => c.String());
            AlterColumn("dbo.EditProfileViewModels", "UserType", c => c.String());
            AlterColumn("dbo.EditProfileViewModels", "Email", c => c.String());
            AlterColumn("dbo.EditProfileViewModels", "CurrentPassword", c => c.String(maxLength: 100));
            AlterColumn("dbo.EditProfileViewModels", "NewPassword", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EditProfileViewModels", "NewPassword", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.EditProfileViewModels", "CurrentPassword", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.EditProfileViewModels", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.EditProfileViewModels", "UserType", c => c.String(nullable: false));
            AlterColumn("dbo.EditProfileViewModels", "UserName", c => c.String(nullable: false));
        }
    }
}
