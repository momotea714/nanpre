namespace Sudoku.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnNanpreAnswerToNanpreQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NanpreQuestions", "NanpreAnswer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.NanpreQuestions", "NanpreAnswer");
        }
    }
}
