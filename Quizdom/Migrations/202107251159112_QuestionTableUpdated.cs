namespace Quizdom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionTableUpdated : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.QuestionChoices", name: "QuestionID_Id", newName: "Question_ID_Id");
            RenameIndex(table: "dbo.QuestionChoices", name: "IX_QuestionID_Id", newName: "IX_Question_ID_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.QuestionChoices", name: "IX_Question_ID_Id", newName: "IX_QuestionID_Id");
            RenameColumn(table: "dbo.QuestionChoices", name: "Question_ID_Id", newName: "QuestionID_Id");
        }
    }
}
