namespace EMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeAttendences", "userProfile_PKUserId", "dbo.UserProfiles");
            DropForeignKey("dbo.EmployeeLeaves", "userProfile_PKUserId", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfiles", "Role_PKRoleId", "dbo.Roles");
            DropIndex("dbo.EmployeeAttendences", new[] { "userProfile_PKUserId" });
            DropIndex("dbo.UserProfiles", new[] { "Role_PKRoleId" });
            DropIndex("dbo.EmployeeLeaves", new[] { "userProfile_PKUserId" });
            DropColumn("dbo.EmployeeAttendences", "userProfile_PKUserId");
            DropColumn("dbo.UserProfiles", "Role_PKRoleId");
            DropColumn("dbo.EmployeeLeaves", "userProfile_PKUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeeLeaves", "userProfile_PKUserId", c => c.Int());
            AddColumn("dbo.UserProfiles", "Role_PKRoleId", c => c.Int());
            AddColumn("dbo.EmployeeAttendences", "userProfile_PKUserId", c => c.Int());
            CreateIndex("dbo.EmployeeLeaves", "userProfile_PKUserId");
            CreateIndex("dbo.UserProfiles", "Role_PKRoleId");
            CreateIndex("dbo.EmployeeAttendences", "userProfile_PKUserId");
            AddForeignKey("dbo.UserProfiles", "Role_PKRoleId", "dbo.Roles", "PKRoleId");
            AddForeignKey("dbo.EmployeeLeaves", "userProfile_PKUserId", "dbo.UserProfiles", "PKUserId");
            AddForeignKey("dbo.EmployeeAttendences", "userProfile_PKUserId", "dbo.UserProfiles", "PKUserId");
        }
    }
}
