namespace RIA.Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170530 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.T_CInfo", name: "Fk_Id", newName: "Fk_Item_CInfo_Id");
            RenameColumn(table: "dbo.T_Class", name: "Fk_Id", newName: "Fk_Item_Id");
            RenameColumn(table: "dbo.T_Staff", name: "FK_GroupId", newName: "FK_Staff_GroupId");
            RenameColumn(table: "dbo.T_HClass", name: "FK_ClassId", newName: "FK_HClass_ClassId");
            RenameColumn(table: "dbo.T_KPoint", name: "Fk_Id", newName: "Fk_Item_KPoint_Id");
            RenameColumn(table: "dbo.T_Require", name: "Fk_UserId", newName: "Fk_Require_UserId");
            RenameIndex(table: "dbo.T_CInfo", name: "IX_Fk_Id", newName: "IX_Fk_Item_CInfo_Id");
            RenameIndex(table: "dbo.T_Class", name: "IX_Fk_Id", newName: "IX_Fk_Item_Id");
            RenameIndex(table: "dbo.T_Staff", name: "IX_FK_GroupId", newName: "IX_FK_Staff_GroupId");
            RenameIndex(table: "dbo.T_HClass", name: "IX_FK_ClassId", newName: "IX_FK_HClass_ClassId");
            RenameIndex(table: "dbo.T_KPoint", name: "IX_Fk_Id", newName: "IX_Fk_Item_KPoint_Id");
            RenameIndex(table: "dbo.T_Require", name: "IX_Fk_UserId", newName: "IX_Fk_Require_UserId");
            AddColumn("dbo.T_CInfo", "Fk_CInfo_UserId", c => c.Int(nullable: false));
            AddColumn("dbo.T_HClass", "FK_HClass_UserId", c => c.Int(nullable: false));
            AddColumn("dbo.T_Require", "Fk_Item_Require_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.T_Require", "Fk_Item_Require_Id");
            AddForeignKey("dbo.T_Require", "Fk_Item_Require_Id", "dbo.T_Item", "Id", cascadeDelete: true);
            DropColumn("dbo.T_CInfo", "Fk_UserId");
            DropColumn("dbo.T_HClass", "FK_UserId");
            DropColumn("dbo.T_Require", "Fk_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_Require", "Fk_Id", c => c.Int(nullable: false));
            AddColumn("dbo.T_HClass", "FK_UserId", c => c.Int(nullable: false));
            AddColumn("dbo.T_CInfo", "Fk_UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.T_Require", "Fk_Item_Require_Id", "dbo.T_Item");
            DropIndex("dbo.T_Require", new[] { "Fk_Item_Require_Id" });
            DropColumn("dbo.T_Require", "Fk_Item_Require_Id");
            DropColumn("dbo.T_HClass", "FK_HClass_UserId");
            DropColumn("dbo.T_CInfo", "Fk_CInfo_UserId");
            RenameIndex(table: "dbo.T_Require", name: "IX_Fk_Require_UserId", newName: "IX_Fk_UserId");
            RenameIndex(table: "dbo.T_KPoint", name: "IX_Fk_Item_KPoint_Id", newName: "IX_Fk_Id");
            RenameIndex(table: "dbo.T_HClass", name: "IX_FK_HClass_ClassId", newName: "IX_FK_ClassId");
            RenameIndex(table: "dbo.T_Staff", name: "IX_FK_Staff_GroupId", newName: "IX_FK_GroupId");
            RenameIndex(table: "dbo.T_Class", name: "IX_Fk_Item_Id", newName: "IX_Fk_Id");
            RenameIndex(table: "dbo.T_CInfo", name: "IX_Fk_Item_CInfo_Id", newName: "IX_Fk_Id");
            RenameColumn(table: "dbo.T_Require", name: "Fk_Require_UserId", newName: "Fk_UserId");
            RenameColumn(table: "dbo.T_KPoint", name: "Fk_Item_KPoint_Id", newName: "Fk_Id");
            RenameColumn(table: "dbo.T_HClass", name: "FK_HClass_ClassId", newName: "FK_ClassId");
            RenameColumn(table: "dbo.T_Staff", name: "FK_Staff_GroupId", newName: "FK_GroupId");
            RenameColumn(table: "dbo.T_Class", name: "Fk_Item_Id", newName: "Fk_Id");
            RenameColumn(table: "dbo.T_CInfo", name: "Fk_Item_CInfo_Id", newName: "Fk_Id");
        }
    }
}
