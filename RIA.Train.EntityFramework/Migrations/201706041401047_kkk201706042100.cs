namespace RIA.Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kkk201706042100 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.T_Require", "Fk_Require_UserId", "dbo.T_User");
            DropIndex("dbo.T_Require", new[] { "Fk_Require_UserId" });
            AddColumn("dbo.T_Require", "Fk_Require_T_Staff_UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.T_Require", "Fk_Require_T_Staff_UserId");
            AddForeignKey("dbo.T_Require", "Fk_Require_T_Staff_UserId", "dbo.T_Staff", "Id", cascadeDelete: true);
            DropColumn("dbo.T_Require", "Fk_Require_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_Require", "Fk_Require_UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.T_Require", "Fk_Require_T_Staff_UserId", "dbo.T_Staff");
            DropIndex("dbo.T_Require", new[] { "Fk_Require_T_Staff_UserId" });
            DropColumn("dbo.T_Require", "Fk_Require_T_Staff_UserId");
            CreateIndex("dbo.T_Require", "Fk_Require_UserId");
            AddForeignKey("dbo.T_Require", "Fk_Require_UserId", "dbo.T_User", "Id", cascadeDelete: true);
        }
    }
}
