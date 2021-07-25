namespace Quizdom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "User_ID", "dbo.Users");
            DropIndex("dbo.Questions", new[] { "User_ID" });
            AddColumn("dbo.Questions", "QuizTilte", c => c.String(maxLength: 50));
            AddColumn("dbo.Questions", "Points", c => c.Int(nullable: false));
            AddColumn("dbo.Questions", "DateCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.Questions", "User_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "User_ID", c => c.Int());
            DropColumn("dbo.Questions", "DateCreated");
            DropColumn("dbo.Questions", "Points");
            DropColumn("dbo.Questions", "QuizTilte");
            CreateIndex("dbo.Questions", "User_ID");
            AddForeignKey("dbo.Questions", "User_ID", "dbo.Users", "ID");
        }
    }
}
