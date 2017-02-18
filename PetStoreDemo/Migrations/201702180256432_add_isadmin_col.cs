namespace PetStoreDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_isadmin_col : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "isAdmin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "isAdmin");
        }
    }
}
