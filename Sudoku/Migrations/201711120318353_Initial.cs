namespace Sudoku.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Momoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NanpreNO = c.Int(nullable: false),
                        MakeUserID = c.String(),
                        IsPublic = c.Boolean(nullable: false),
                        Title = c.String(),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Momoes");
        }
    }
}
