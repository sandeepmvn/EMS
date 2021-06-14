namespace EMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringlength_for_Rolename : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Roles", "RoleName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "RoleName", c => c.String(nullable: false));
        }
    }
}
