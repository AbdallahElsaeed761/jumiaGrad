namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editPayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "cardName", c => c.String(nullable: false, maxLength: 16));
            AddColumn("dbo.Payments", "cardOwnerName", c => c.String(nullable: false));
            AddColumn("dbo.Payments", "userID", c => c.String());
            AddColumn("dbo.Payments", "applicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Payments", "applicationUser_Id");
            AddForeignKey("dbo.Payments", "applicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "applicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Payments", new[] { "applicationUser_Id" });
            DropColumn("dbo.Payments", "applicationUser_Id");
            DropColumn("dbo.Payments", "userID");
            DropColumn("dbo.Payments", "cardOwnerName");
            DropColumn("dbo.Payments", "cardName");
        }
    }
}
