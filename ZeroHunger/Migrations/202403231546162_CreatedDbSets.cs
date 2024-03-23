namespace ZeroHunger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDbSets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accesses",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        UploadDate = c.DateTime(nullable: false),
                        ExpireTime = c.DateTime(nullable: false),
                        CompleteTime = c.DateTime(),
                        Amount = c.String(nullable: false),
                        StatusName = c.String(nullable: false, maxLength: 128),
                        AssignedTo = c.Guid(),
                        RestaurantId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.AssignedTo)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusName, cascadeDelete: true)
                .Index(t => t.StatusName)
                .Index(t => t.AssignedTo)
                .Index(t => t.RestaurantId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false),
                        AccessName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accesses", t => t.AccessName)
                .Index(t => t.UserName, unique: true)
                .Index(t => t.AccessName);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foods", "StatusName", "dbo.Status");
            DropForeignKey("dbo.Foods", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Restaurants", "Id", "dbo.Users");
            DropForeignKey("dbo.Users", "AccessName", "dbo.Accesses");
            DropForeignKey("dbo.Foods", "AssignedTo", "dbo.Employees");
            DropIndex("dbo.Users", new[] { "AccessName" });
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.Restaurants", new[] { "Id" });
            DropIndex("dbo.Foods", new[] { "RestaurantId" });
            DropIndex("dbo.Foods", new[] { "AssignedTo" });
            DropIndex("dbo.Foods", new[] { "StatusName" });
            DropTable("dbo.Status");
            DropTable("dbo.Users");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Foods");
            DropTable("dbo.Employees");
            DropTable("dbo.Accesses");
        }
    }
}
