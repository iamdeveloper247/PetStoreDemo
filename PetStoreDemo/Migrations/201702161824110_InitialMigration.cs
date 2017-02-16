namespace PetStoreDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pets",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Category = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Status",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.Pets", "statusId", c => c.Int(nullable: true));
            CreateIndex("dbo.Pets", "statusId");
            AddForeignKey("dbo.Pets", "statusId", "dbo.Status", "Id", cascadeDelete: true);


            CreateTable(
              "dbo.Users",
              c => new
              {
                  Id = c.Int(nullable: false, identity: true),
                  UserName = c.String(),
                  FullName = c.String(),
                  Password = c.String(),
              })
              .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.Pets");

            DropForeignKey("dbo.Pets", "statusId", "dbo.Status");
            DropIndex("dbo.Pets", new[] { "statusId" });
            DropColumn("dbo.Pets", "statusId");
            DropTable("dbo.Status");

            DropTable("dbo.Users");
        }
    }
}
