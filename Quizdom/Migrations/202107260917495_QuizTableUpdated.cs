using System;
using System.Data.Entity.Migrations;

namespace Quizdom.Migrations
{
    public partial class QuizTableUpdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quizs",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    QuizTilte = c.String(maxLength: 50),
                    IsActive = c.Boolean(nullable: false),
                    DateCreated = c.DateTime(nullable: false),
                    Link = c.String(),
                    User_ID = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
        }
        public override void Down()
        {
            DropForeignKey("dbo.Quizs", "User_ID", "dbo.Users");
            DropIndex("dbo.Quizs", new[] { "User_ID" });
            DropTable("dbo.Quizs");
        }
    }
}
