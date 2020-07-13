namespace DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PayslipUserIDDifferentThanID_AppUser_mdb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.__AppUsers", "Id", "dbo.PayslipUsers");
            DropIndex("dbo.__AppUsers", new[] { "Id" });
            AddColumn("dbo.__AppUsers", "PayslipUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.__AppUsers", "PayslipUserID");
            AddForeignKey("dbo.__AppUsers", "PayslipUserID", "dbo.PayslipUsers", "Badge");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.__AppUsers", "PayslipUserID", "dbo.PayslipUsers");
            DropIndex("dbo.__AppUsers", new[] { "PayslipUserID" });
            DropColumn("dbo.__AppUsers", "PayslipUserID");
            CreateIndex("dbo.__AppUsers", "Id");
            AddForeignKey("dbo.__AppUsers", "Id", "dbo.PayslipUsers", "Badge");
        }
    }
}
