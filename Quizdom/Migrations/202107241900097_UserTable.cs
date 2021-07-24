namespace Quizdom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FirstName", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "LastName", c => c.String(maxLength: 50));
            AddColumn("dbo.Users", "Email", c => c.String(maxLength: 50));
            DropColumn("dbo.Users", "Name");
        }

        public override void Down()
        {
            AddColumn("dbo.Users", "Name", c => c.String());
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
        }
    }
}
