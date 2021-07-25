namespace Quizdom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinorChangesInQuestionChoices : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.QuestionChoices", name: "Question_ID_Id", newName: "Question_Id");
            RenameIndex(table: "dbo.QuestionChoices", name: "IX_Question_ID_Id", newName: "IX_Question_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.QuestionChoices", name: "IX_Question_Id", newName: "IX_Question_ID_Id");
            RenameColumn(table: "dbo.QuestionChoices", name: "Question_Id", newName: "Question_ID_Id");
        }
    }
}
