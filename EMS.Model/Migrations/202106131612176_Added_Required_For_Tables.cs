namespace EMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Required_For_Tables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeLeaves", "Reason", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Roles", "RoleName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "RoleName", c => c.String());
            AlterColumn("dbo.EmployeeLeaves", "Reason", c => c.String());
        }
    }
}
