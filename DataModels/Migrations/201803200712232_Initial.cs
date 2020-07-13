namespace DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.__AppRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Description = c.String(),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.__AppUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.__AppRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.__AppUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            CreateTable(
                "dbo.__AppUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PayslipUsers", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.__AppUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.__AppUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.__AppUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.__AppUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.__AppUsers", "Id", "dbo.PayslipUsers");
            DropForeignKey("dbo.__AppUserRoles", "UserId", "dbo.__AppUsers");
            DropForeignKey("dbo.__AppUserLogins", "UserId", "dbo.__AppUsers");
            DropForeignKey("dbo.__AppUserClaims", "UserId", "dbo.__AppUsers");
            DropForeignKey("dbo.__AppUserRoles", "RoleId", "dbo.__AppRoles");
            DropIndex("dbo.__AppUserLogins", new[] { "UserId" });
            DropIndex("dbo.__AppUserClaims", new[] { "UserId" });
            DropIndex("dbo.__AppUsers", "UserNameIndex");
            DropIndex("dbo.__AppUsers", new[] { "Id" });
            DropIndex("dbo.__AppUserRoles", new[] { "RoleId" });
            DropIndex("dbo.__AppUserRoles", new[] { "UserId" });
            DropIndex("dbo.__AppRoles", "RoleNameIndex");
            DropTable("dbo.__AppUserLogins");
            DropTable("dbo.__AppUserClaims");
            DropTable("dbo.__AppUsers");
            DropTable("dbo.__AppUserRoles");
            DropTable("dbo.__AppRoles");
        }
    }
}