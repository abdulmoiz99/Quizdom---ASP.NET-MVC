namespace Quizdom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionTableModified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionChoices", "Question_Id", "dbo.Questions");
            DropIndex("dbo.QuestionChoices", new[] { "Question_Id" });
            AddColumn("dbo.Questions", "ChoiceA", c => c.String(maxLength: 50));
            AddColumn("dbo.Questions", "ChoiceB", c => c.String(maxLength: 50));
            AddColumn("dbo.Questions", "ChoiceC", c => c.String(maxLength: 50));
            AddColumn("dbo.Questions", "ChoiceD", c => c.String(maxLength: 50));
            AddColumn("dbo.Questions", "CorrectChoice", c => c.String(maxLength: 1));
            AddColumn("dbo.Questions", "User_ID", c => c.Int());
            AlterColumn("dbo.Questions", "Question", c => c.String(maxLength: 50));
            CreateIndex("dbo.Questions", "User_ID");
            AddForeignKey("dbo.Questions", "User_ID", "dbo.Users", "ID");
            DropTable("dbo.QuestionChoices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.QuestionChoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Choice = c.String(),
                        IsRight = c.Boolean(nullable: false),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Questions", "User_ID", "dbo.Users");
            DropIndex("dbo.Questions", new[] { "User_ID" });
            AlterColumn("dbo.Questions", "Question", c => c.String());
            DropColumn("dbo.Questions", "User_ID");
            DropColumn("dbo.Questions", "CorrectChoice");
            DropColumn("dbo.Questions", "ChoiceD");
            DropColumn("dbo.Questions", "ChoiceC");
            DropColumn("dbo.Questions", "ChoiceB");
            DropColumn("dbo.Questions", "ChoiceA");
            CreateIndex("dbo.QuestionChoices", "Question_Id");
            AddForeignKey("dbo.QuestionChoices", "Question_Id", "dbo.Questions", "Id");
        }
    }
}
