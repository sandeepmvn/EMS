namespace EMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPassword_column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "Password");
        }
    }
}
