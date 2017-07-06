namespace RIA.Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201706032230 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.T_Estimate_Detail", "FK_UserId", "dbo.T_User");
            DropIndex("dbo.T_Estimate_Detail", new[] { "FK_UserId" });
            AddColumn("dbo.T_Estimate_Detail", "FK_TstaffId", c => c.Int(nullable: false));
            AddColumn("dbo.T_Staff", "LoginNo", c => c.Int(nullable: false));
            AddColumn("dbo.T_Staff", "PassWord", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.T_Staff", "OpenId", c => c.String(maxLength: 100, unicode: false));
            CreateIndex("dbo.T_CInfo", "Fk_CInfo_UserId");
            CreateIndex("dbo.T_Estimate_Detail", "FK_TstaffId");
            AddForeignKey("dbo.T_CInfo", "Fk_CInfo_UserId", "dbo.T_Staff", "Id", cascadeDelete: true);
            AddForeignKey("dbo.T_Estimate_Detail", "FK_TstaffId", "dbo.T_Staff", "Id", cascadeDelete: true);
            DropColumn("dbo.T_Estimate_Detail", "FK_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_Estimate_Detail", "FK_UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.T_Estimate_Detail", "FK_TstaffId", "dbo.T_Staff");
            DropForeignKey("dbo.T_CInfo", "Fk_CInfo_UserId", "dbo.T_Staff");
            DropIndex("dbo.T_Estimate_Detail", new[] { "FK_TstaffId" });
            DropIndex("dbo.T_CInfo", new[] { "Fk_CInfo_UserId" });
            DropColumn("dbo.T_Staff", "OpenId");
            DropColumn("dbo.T_Staff", "PassWord");
            DropColumn("dbo.T_Staff", "LoginNo");
            DropColumn("dbo.T_Estimate_Detail", "FK_TstaffId");
            CreateIndex("dbo.T_Estimate_Detail", "FK_UserId");
            AddForeignKey("dbo.T_Estimate_Detail", "FK_UserId", "dbo.T_User", "Id", cascadeDelete: true);
        }
    }
}
