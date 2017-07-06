namespace RIA.Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kkk201706042100pp : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.T_Require", name: "Fk_Require_T_Staff_UserId", newName: "Fk_Require_UserId");
            RenameIndex(table: "dbo.T_Require", name: "IX_Fk_Require_T_Staff_UserId", newName: "IX_Fk_Require_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.T_Require", name: "IX_Fk_Require_UserId", newName: "IX_Fk_Require_T_Staff_UserId");
            RenameColumn(table: "dbo.T_Require", name: "Fk_Require_UserId", newName: "Fk_Require_T_Staff_UserId");
        }
    }
}
