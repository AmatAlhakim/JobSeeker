namespace JobSeeker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEditProfileModelAddPhoneNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EditProfileViewModels", "Number", c => c.String());
            DropColumn("dbo.EditProfileViewModels", "CurrentPassword");
            DropColumn("dbo.EditProfileViewModels", "NewPassword");
            DropColumn("dbo.EditProfileViewModels", "ConfirmPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EditProfileViewModels", "ConfirmPassword", c => c.String());
            AddColumn("dbo.EditProfileViewModels", "NewPassword", c => c.String(maxLength: 100));
            AddColumn("dbo.EditProfileViewModels", "CurrentPassword", c => c.String(maxLength: 100));
            DropColumn("dbo.EditProfileViewModels", "Number");
        }
    }
}
