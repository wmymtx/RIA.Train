namespace RIA.Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170604 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Require", "CheckKPoint", c => c.String());
            AddColumn("dbo.T_Require", "ChectKPointId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Require", "ChectKPointId");
            DropColumn("dbo.T_Require", "CheckKPoint");
        }
    }
}
