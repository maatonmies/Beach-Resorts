namespace HoidayResorts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resorts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                        Location = c.String(),
                        Rating = c.Double(nullable: false),
                        CheapestRoom = c.Int(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        ReviewText = c.String(),
                        ResortId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resorts", t => t.ResortId, cascadeDelete: true)
                .Index(t => t.ResortId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "ResortId", "dbo.Resorts");
            DropIndex("dbo.Reviews", new[] { "ResortId" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Resorts");
        }
    }
}
