namespace CarDealership.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixColumns : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Role", c => c.String());
        }
    }
}
