namespace EMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeAttendences",
                c => new
                    {
                        PKAttendanceId = c.Int(nullable: false, identity: true),
                        FKEmployeeId = c.Int(nullable: false),
                        AttendanceOn = c.DateTime(nullable: false),
                        WorkingHours = c.Int(nullable: false),
                        userProfile_PKUserId = c.Int(),
                    })
                .PrimaryKey(t => t.PKAttendanceId)
                .ForeignKey("dbo.UserProfiles", t => t.userProfile_PKUserId)
                .Index(t => t.userProfile_PKUserId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        PKUserId = c.Int(nullable: false, identity: true),
                        FKRoleId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        EmailId = c.String(),
                        PhoneNumber = c.String(),
                        Designation = c.String(),
                        Gender = c.String(),
                        Address = c.String(),
                        Workplace = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Role_PKRoleId = c.Int(),
                    })
                .PrimaryKey(t => t.PKUserId)
                .ForeignKey("dbo.Roles", t => t.Role_PKRoleId)
                .Index(t => t.Role_PKRoleId);
            
            CreateTable(
                "dbo.EmployeeLeaves",
                c => new
                    {
                        PKLeaveId = c.Int(nullable: false, identity: true),
                        FKEmployeeId = c.Int(nullable: false),
                        NoOfDays = c.Int(nullable: false),
                        Reason = c.String(),
                        Status = c.String(),
                        userProfile_PKUserId = c.Int(),
                    })
                .PrimaryKey(t => t.PKLeaveId)
                .ForeignKey("dbo.UserProfiles", t => t.userProfile_PKUserId)
                .Index(t => t.userProfile_PKUserId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        PKRoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.PKRoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "Role_PKRoleId", "dbo.Roles");
            DropForeignKey("dbo.EmployeeLeaves", "userProfile_PKUserId", "dbo.UserProfiles");
            DropForeignKey("dbo.EmployeeAttendences", "userProfile_PKUserId", "dbo.UserProfiles");
            DropIndex("dbo.EmployeeLeaves", new[] { "userProfile_PKUserId" });
            DropIndex("dbo.UserProfiles", new[] { "Role_PKRoleId" });
            DropIndex("dbo.EmployeeAttendences", new[] { "userProfile_PKUserId" });
            DropTable("dbo.Roles");
            DropTable("dbo.EmployeeLeaves");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.EmployeeAttendences");
        }
    }
}
