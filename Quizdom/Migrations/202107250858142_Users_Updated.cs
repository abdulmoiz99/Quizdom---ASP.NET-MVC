namespace Quizdom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users_Updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "IsActive", c => c.Boolean(nullable: false));
        }
        public override void Down()
        {
            DropColumn("dbo.Users", "IsActive");
            DropColumn("dbo.Users", "DateCreated");
        }
    }
}
