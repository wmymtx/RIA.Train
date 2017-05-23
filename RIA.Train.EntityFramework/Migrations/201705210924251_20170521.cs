namespace RIA.Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20170521 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_CInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fk_Id = c.Int(nullable: false),
                        Fk_UserId = c.Int(nullable: false),
                        UserName = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Item", t => t.Fk_Id, cascadeDelete: true)
                .Index(t => t.Fk_Id);
            
            CreateTable(
                "dbo.T_Item",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(maxLength: 30),
                        CreateTime = c.DateTime(),
                        CreatorUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Class",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fk_Id = c.Int(nullable: false),
                        TrainingTime = c.DateTime(),
                        TrainingPlace = c.String(maxLength: 50, unicode: false),
                        TrainintTeacher = c.String(maxLength: 30, unicode: false),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Item", t => t.Fk_Id, cascadeDelete: true)
                .Index(t => t.Fk_Id);
            
            CreateTable(
                "dbo.T_Content",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Dep",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Estimate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FK_ClassId = c.Int(nullable: false),
                        FK_ContentId = c.Int(nullable: false),
                        FK_GradeId = c.Int(nullable: false),
                        ContentCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Class", t => t.FK_ClassId, cascadeDelete: true)
                .ForeignKey("dbo.T_Content", t => t.FK_ContentId, cascadeDelete: true)
                .ForeignKey("dbo.T_Grade", t => t.FK_GradeId, cascadeDelete: true)
                .Index(t => t.FK_ClassId)
                .Index(t => t.FK_ContentId)
                .Index(t => t.FK_GradeId);
            
            CreateTable(
                "dbo.T_Grade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Grade = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.T_Estimate_Detail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FK_EstimateId = c.Int(nullable: false),
                        FK_UserId = c.Int(nullable: false),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Estimate", t => t.FK_EstimateId, cascadeDelete: true)
                .ForeignKey("dbo.T_User", t => t.FK_UserId, cascadeDelete: true)
                .Index(t => t.FK_EstimateId)
                .Index(t => t.FK_UserId);
            
            CreateTable(
                "dbo.T_User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FK_StaffId = c.Int(nullable: false),
                        LoginNo = c.Int(nullable: false),
                        PassWord = c.String(maxLength: 50, unicode: false),
                        OpenId = c.String(maxLength: 100, unicode: false),
                        CreteTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Staff", t => t.FK_StaffId, cascadeDelete: true)
                .Index(t => t.FK_StaffId);
            
            CreateTable(
                "dbo.T_Staff",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FK_GroupId = c.Int(nullable: false),
                        StaffName = c.String(maxLength: 30, unicode: false),
                        CreteTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Group", t => t.FK_GroupId, cascadeDelete: true)
                .Index(t => t.FK_GroupId);
            
            CreateTable(
                "dbo.T_Group",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FK_DepId = c.Int(nullable: false),
                        GroupName = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Dep", t => t.FK_DepId, cascadeDelete: true)
                .Index(t => t.FK_DepId);
            
            CreateTable(
                "dbo.T_HClass",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FK_ClassId = c.Int(nullable: false),
                        FK_UserId = c.Int(nullable: false),
                        UserName = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Class", t => t.FK_ClassId, cascadeDelete: true)
                .Index(t => t.FK_ClassId);
            
            CreateTable(
                "dbo.T_KPoint",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fk_Id = c.Int(nullable: false),
                        TrainContent = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_Item", t => t.Fk_Id, cascadeDelete: true)
                .Index(t => t.Fk_Id);
            
            CreateTable(
                "dbo.T_Require",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fk_Id = c.Int(nullable: false),
                        Fk_UserId = c.Int(nullable: false),
                        UserName = c.String(maxLength: 30, unicode: false),
                        Content = c.String(maxLength: 500, unicode: false),
                        SubmitTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.T_User", t => t.Fk_UserId, cascadeDelete: true)
                .Index(t => t.Fk_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_Require", "Fk_UserId", "dbo.T_User");
            DropForeignKey("dbo.T_KPoint", "Fk_Id", "dbo.T_Item");
            DropForeignKey("dbo.T_HClass", "FK_ClassId", "dbo.T_Class");
            DropForeignKey("dbo.T_Estimate_Detail", "FK_UserId", "dbo.T_User");
            DropForeignKey("dbo.T_User", "FK_StaffId", "dbo.T_Staff");
            DropForeignKey("dbo.T_Staff", "FK_GroupId", "dbo.T_Group");
            DropForeignKey("dbo.T_Group", "FK_DepId", "dbo.T_Dep");
            DropForeignKey("dbo.T_Estimate_Detail", "FK_EstimateId", "dbo.T_Estimate");
            DropForeignKey("dbo.T_Estimate", "FK_GradeId", "dbo.T_Grade");
            DropForeignKey("dbo.T_Estimate", "FK_ContentId", "dbo.T_Content");
            DropForeignKey("dbo.T_Estimate", "FK_ClassId", "dbo.T_Class");
            DropForeignKey("dbo.T_Class", "Fk_Id", "dbo.T_Item");
            DropForeignKey("dbo.T_CInfo", "Fk_Id", "dbo.T_Item");
            DropIndex("dbo.T_Require", new[] { "Fk_UserId" });
            DropIndex("dbo.T_KPoint", new[] { "Fk_Id" });
            DropIndex("dbo.T_HClass", new[] { "FK_ClassId" });
            DropIndex("dbo.T_Group", new[] { "FK_DepId" });
            DropIndex("dbo.T_Staff", new[] { "FK_GroupId" });
            DropIndex("dbo.T_User", new[] { "FK_StaffId" });
            DropIndex("dbo.T_Estimate_Detail", new[] { "FK_UserId" });
            DropIndex("dbo.T_Estimate_Detail", new[] { "FK_EstimateId" });
            DropIndex("dbo.T_Estimate", new[] { "FK_GradeId" });
            DropIndex("dbo.T_Estimate", new[] { "FK_ContentId" });
            DropIndex("dbo.T_Estimate", new[] { "FK_ClassId" });
            DropIndex("dbo.T_Class", new[] { "Fk_Id" });
            DropIndex("dbo.T_CInfo", new[] { "Fk_Id" });
            DropTable("dbo.T_Require");
            DropTable("dbo.T_KPoint");
            DropTable("dbo.T_HClass");
            DropTable("dbo.T_Group");
            DropTable("dbo.T_Staff");
            DropTable("dbo.T_User");
            DropTable("dbo.T_Estimate_Detail");
            DropTable("dbo.T_Grade");
            DropTable("dbo.T_Estimate");
            DropTable("dbo.T_Dep");
            DropTable("dbo.T_Content");
            DropTable("dbo.T_Class");
            DropTable("dbo.T_Item");
            DropTable("dbo.T_CInfo");
        }
    }
}
