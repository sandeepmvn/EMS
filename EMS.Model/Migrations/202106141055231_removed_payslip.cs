namespace EMS.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_payslip : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Payslips");
        }
        
        public override void Down()
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
    }
}
