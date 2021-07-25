namespace Quizdom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "User_ID", c => c.Int());
            CreateIndex("dbo.Questions", "User_ID");
            AddForeignKey("dbo.Questions", "User_ID", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "User_ID", "dbo.Users");
            DropIndex("dbo.Questions", new[] { "User_ID" });
            DropColumn("dbo.Questions", "User_ID");
        }
    }
}
