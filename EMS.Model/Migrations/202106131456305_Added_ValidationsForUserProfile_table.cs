namespace EMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_ValidationsForUserProfile_table : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfiles", "Password", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserProfiles", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserProfiles", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.UserProfiles", "EmailId", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserProfiles", "PhoneNumber", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.UserProfiles", "Designation", c => c.String(maxLength: 50));
            AlterColumn("dbo.UserProfiles", "Gender", c => c.String(maxLength: 10));
            AlterColumn("dbo.UserProfiles", "Address", c => c.String(maxLength: 500));
            AlterColumn("dbo.UserProfiles", "Workplace", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfiles", "Workplace", c => c.String());
            AlterColumn("dbo.UserProfiles", "Address", c => c.String());
            AlterColumn("dbo.UserProfiles", "Gender", c => c.String());
            AlterColumn("dbo.UserProfiles", "Designation", c => c.String());
            AlterColumn("dbo.UserProfiles", "PhoneNumber", c => c.String());
            AlterColumn("dbo.UserProfiles", "EmailId", c => c.String());
            AlterColumn("dbo.UserProfiles", "LastName", c => c.String());
            AlterColumn("dbo.UserProfiles", "FirstName", c => c.String());
            AlterColumn("dbo.UserProfiles", "Password", c => c.String());
        }
    }
}
