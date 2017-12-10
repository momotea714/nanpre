namespace Sudoku.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Talk_Update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Talks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Momo_ID = c.Int(nullable: false),
                        SenderUser_ID = c.String(),
                        DisplayName = c.String(),
                        Message = c.String(),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Talks");
        }
    }
}
