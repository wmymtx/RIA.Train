namespace RIA.Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170603 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.T_Group", "FK_DepId", "dbo.T_Dep");
            DropIndex("dbo.T_Group", new[] { "FK_DepId" });
            AddColumn("dbo.T_Group", "ParentId", c => c.Int(nullable: false));
            DropColumn("dbo.T_Group", "FK_DepId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_Group", "FK_DepId", c => c.Int(nullable: false));
            DropColumn("dbo.T_Group", "ParentId");
            CreateIndex("dbo.T_Group", "FK_DepId");
            AddForeignKey("dbo.T_Group", "FK_DepId", "dbo.T_Dep", "Id", cascadeDelete: true);
        }
    }
}
