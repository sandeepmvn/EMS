namespace EMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_payslip : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payslips",
                c => new
                    {
                        PKPayslipId = c.Int(nullable: false, identity: true),
                        FKEmployeeId = c.Int(nullable: false),
                        MonthDate = c.DateTime(nullable: false),
                        CreditedOn = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PKPayslipId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Payslips");
        }
    }
}
