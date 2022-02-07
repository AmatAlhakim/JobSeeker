namespace JobSeeker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobApplicationTableToDb2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false),
                        ApplicationDate = c.DateTime(nullable: false),
                        JobId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.JobId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobApplications", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.JobApplications", "JobId", "dbo.Jobs");
            DropIndex("dbo.JobApplications", new[] { "UserId" });
            DropIndex("dbo.JobApplications", new[] { "JobId" });
            DropTable("dbo.JobApplications");
        }
    }
}
