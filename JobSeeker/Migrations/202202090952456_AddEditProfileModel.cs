namespace JobSeeker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEditProfileModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EditProfileViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        UserType = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        CurrentPassword = c.String(nullable: false, maxLength: 100),
                        NewPassword = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EditProfileViewModels");
        }
    }
}
