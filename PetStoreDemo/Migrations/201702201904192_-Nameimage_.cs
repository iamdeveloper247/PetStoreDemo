namespace PetStoreDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nameimage_ : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pets", "imgname", c => c.String());
            AddColumn("dbo.Pets", "img", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pets", "img");
            DropColumn("dbo.Pets", "imgname");
        }
    }
}
