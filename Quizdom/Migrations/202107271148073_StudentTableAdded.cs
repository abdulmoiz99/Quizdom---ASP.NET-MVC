namespace Quizdom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Score = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Quiz_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Quizs", t => t.Quiz_Id)
                .Index(t => t.Quiz_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Quiz_Id", "dbo.Quizs");
            DropIndex("dbo.Students", new[] { "Quiz_Id" });
            DropTable("dbo.Students");
        }
    }
}
