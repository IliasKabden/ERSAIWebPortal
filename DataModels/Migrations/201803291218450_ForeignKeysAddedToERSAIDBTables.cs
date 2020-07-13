namespace DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeysAddedToERSAIDBTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.__AppUsers", "PayslipUserID", "dbo.PayslipUsers");
            DropIndex("dbo.__AppUsers", new[] { "PayslipUserID" });
            DropPrimaryKey("dbo.EmployeesMobilePhones");
            DropPrimaryKey("dbo.PayslipUsers");
            AlterColumn("dbo.EmployeesMobilePhones", "BadgeNumber", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.KPI_Docs", "Employer_BadgeNumber", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.PayslipUsers", "Badge", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.__AppUsers", "PayslipUserID", c => c.String(maxLength: 10));
            AlterColumn("dbo.RequestAbsence", "RequestorBadge", c => c.String(nullable: false, maxLength: 10));
            AddPrimaryKey("dbo.EmployeesMobilePhones", "BadgeNumber");
            AddPrimaryKey("dbo.PayslipUsers", "Badge");
            CreateIndex("dbo.RequestWifi", "BadgeNumber");
            CreateIndex("dbo.EmployeesMobilePhones", "BadgeNumber");
            CreateIndex("dbo.ICTStaff", "BadgeNumber");
            CreateIndex("dbo.KPI_Docs", "Employer_BadgeNumber");
            CreateIndex("dbo.PayslipUsers", "Badge");
            CreateIndex("dbo.__AppUsers", "PayslipUserID");
            CreateIndex("dbo.RequestAbsence", "RequestorBadge");
            CreateIndex("dbo.RequestPerformers", "BadgeNumber");
            CreateIndex("dbo.SupervisorManager", "BadgeNumber");
            AddForeignKey("dbo.EmployeesMobilePhones", "BadgeNumber", "dbo.Employee", "BadgeNumber");
            AddForeignKey("dbo.RequestWifi", "BadgeNumber", "dbo.Employee", "BadgeNumber", cascadeDelete: true);
            AddForeignKey("dbo.ICTStaff", "BadgeNumber", "dbo.Employee", "BadgeNumber", cascadeDelete: true);
            AddForeignKey("dbo.KPI_Docs", "Employer_BadgeNumber", "dbo.Employee", "BadgeNumber", cascadeDelete: true);
            AddForeignKey("dbo.PayslipUsers", "Badge", "dbo.Employee", "BadgeNumber");
            AddForeignKey("dbo.RequestAbsence", "RequestorBadge", "dbo.Employee", "BadgeNumber", cascadeDelete: true);
            AddForeignKey("dbo.RequestPerformers", "BadgeNumber", "dbo.Employee", "BadgeNumber", cascadeDelete: true);
            AddForeignKey("dbo.SupervisorManager", "BadgeNumber", "dbo.Employee", "BadgeNumber", cascadeDelete: true);
            AddForeignKey("dbo.__AppUsers", "PayslipUserID", "dbo.PayslipUsers", "Badge");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.__AppUsers", "PayslipUserID", "dbo.PayslipUsers");
            DropForeignKey("dbo.SupervisorManager", "BadgeNumber", "dbo.Employee");
            DropForeignKey("dbo.RequestPerformers", "BadgeNumber", "dbo.Employee");
            DropForeignKey("dbo.RequestAbsence", "RequestorBadge", "dbo.Employee");
            DropForeignKey("dbo.PayslipUsers", "Badge", "dbo.Employee");
            DropForeignKey("dbo.KPI_Docs", "Employer_BadgeNumber", "dbo.Employee");
            DropForeignKey("dbo.ICTStaff", "BadgeNumber", "dbo.Employee");
            DropForeignKey("dbo.RequestWifi", "BadgeNumber", "dbo.Employee");
            DropForeignKey("dbo.EmployeesMobilePhones", "BadgeNumber", "dbo.Employee");
            DropIndex("dbo.SupervisorManager", new[] { "BadgeNumber" });
            DropIndex("dbo.RequestPerformers", new[] { "BadgeNumber" });
            DropIndex("dbo.RequestAbsence", new[] { "RequestorBadge" });
            DropIndex("dbo.__AppUsers", new[] { "PayslipUserID" });
            DropIndex("dbo.PayslipUsers", new[] { "Badge" });
            DropIndex("dbo.KPI_Docs", new[] { "Employer_BadgeNumber" });
            DropIndex("dbo.ICTStaff", new[] { "BadgeNumber" });
            DropIndex("dbo.EmployeesMobilePhones", new[] { "BadgeNumber" });
            DropIndex("dbo.RequestWifi", new[] { "BadgeNumber" });
            DropPrimaryKey("dbo.PayslipUsers");
            DropPrimaryKey("dbo.EmployeesMobilePhones");
            AlterColumn("dbo.RequestAbsence", "RequestorBadge", c => c.String(maxLength: 10));
            AlterColumn("dbo.__AppUsers", "PayslipUserID", c => c.String(maxLength: 128));
            AlterColumn("dbo.PayslipUsers", "Badge", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.KPI_Docs", "Employer_BadgeNumber", c => c.String(maxLength: 20));
            AlterColumn("dbo.EmployeesMobilePhones", "BadgeNumber", c => c.String(nullable: false, maxLength: 15));
            AddPrimaryKey("dbo.PayslipUsers", "Badge");
            AddPrimaryKey("dbo.EmployeesMobilePhones", "BadgeNumber");
            CreateIndex("dbo.__AppUsers", "PayslipUserID");
            AddForeignKey("dbo.__AppUsers", "PayslipUserID", "dbo.PayslipUsers", "Badge");
        }
    }
}
