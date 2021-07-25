namespace Quizdom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuizTableAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "User_ID", "dbo.Users");
            DropIndex("dbo.Questions", new[] { "User_ID" });
            DropColumn("dbo.Questions", "QuizTilte");
            DropColumn("dbo.Questions", "DateCreated");
            DropColumn("dbo.Questions", "User_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "User_ID", c => c.Int());
            AddColumn("dbo.Questions", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Questions", "QuizTilte", c => c.String(maxLength: 50));
            CreateIndex("dbo.Questions", "User_ID");
            AddForeignKey("dbo.Questions", "User_ID", "dbo.Users", "ID");
        }
    }
}
