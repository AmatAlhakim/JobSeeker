namespace JobSeeker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfirmChangesToApplyForJobTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplyForJobs", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.ApplyForJobs", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ApplyForJobs", new[] { "JobId" });
            DropIndex("dbo.ApplyForJobs", new[] { "UserId" });
            DropTable("dbo.ApplyForJobs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplyForJobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false),
                        ApplicationDate = c.DateTime(nullable: false),
                        JobId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ApplyForJobs", "UserId");
            CreateIndex("dbo.ApplyForJobs", "JobId");
            AddForeignKey("dbo.ApplyForJobs", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ApplyForJobs", "JobId", "dbo.Jobs", "Id", cascadeDelete: true);
        }
    }
}
