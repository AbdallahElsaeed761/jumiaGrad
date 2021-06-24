namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Lname", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.AspNetUsers", "Lanme");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Lanme", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.AspNetUsers", "Lname");
        }
    }
}
