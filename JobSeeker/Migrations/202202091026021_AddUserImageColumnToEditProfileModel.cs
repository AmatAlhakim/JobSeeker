namespace JobSeeker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserImageColumnToEditProfileModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserImage", c => c.String());
            AddColumn("dbo.EditProfileViewModels", "UserImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EditProfileViewModels", "UserImage");
            DropColumn("dbo.AspNetUsers", "UserImage");
        }
    }
}
