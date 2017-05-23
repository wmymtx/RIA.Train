namespace RIA.Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170523 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_Dep", "DepName", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_Dep", "DepName", c => c.String());
        }
    }
}
