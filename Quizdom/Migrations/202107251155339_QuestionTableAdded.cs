namespace Quizdom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.QuestionChoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Choice = c.String(),
                        IsRight = c.Boolean(nullable: false),
                        QuestionID_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Questions", t => t.QuestionID_Id)
                .Index(t => t.QuestionID_Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionChoices", "QuestionID_Id", "dbo.Questions");
            DropIndex("dbo.QuestionChoices", new[] { "QuestionID_Id" });
            DropTable("dbo.Questions");
            DropTable("dbo.QuestionChoices");
        }
    }
}
