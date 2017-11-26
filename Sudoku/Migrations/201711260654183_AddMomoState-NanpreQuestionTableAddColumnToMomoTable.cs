namespace Sudoku.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMomoStateNanpreQuestionTableAddColumnToMomoTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MomoStates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Momo_ID = c.Int(nullable: false),
                        CurrentNanpre = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.NanpreQuestions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NanpreNO = c.Int(nullable: false),
                        Nanpre = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Momoes", "IsCleared", c => c.Boolean(nullable: false));
            AddColumn("dbo.Momoes", "CreatedDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Momoes", "CreatedDateTime");
            DropColumn("dbo.Momoes", "IsCleared");
            DropTable("dbo.NanpreQuestions");
            DropTable("dbo.MomoStates");
        }
    }
}
