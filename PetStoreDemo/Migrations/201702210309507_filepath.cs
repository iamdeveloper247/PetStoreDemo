namespace PetStoreDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filepath : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        FileType = c.Int(nullable: false),
                        PetID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilePathId)
                .ForeignKey("dbo.Pets", t => t.PetID, cascadeDelete: true)
                .Index(t => t.PetID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilePaths", "PetID", "dbo.Pets");
            DropIndex("dbo.FilePaths", new[] { "PetID" });
            DropTable("dbo.FilePaths");
        }
    }
}
