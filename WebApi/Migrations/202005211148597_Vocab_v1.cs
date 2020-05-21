namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vocab_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NameLevel = c.String(),
                        NumberWord = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MyPackages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PackageId = c.String(maxLength: 128),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.PackageId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.PackageId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NamePackage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WordGroups",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PackageId = c.String(maxLength: 128),
                        GroupName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.PackageId)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        WordGroupId = c.String(maxLength: 128),
                        W = c.String(),
                        Explain = c.String(),
                        Example = c.String(),
                        Synomymous = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WordGroups", t => t.WordGroupId)
                .Index(t => t.WordGroupId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Age = c.String(),
                        Sex = c.String(),
                        Job = c.String(),
                        Livein = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WordMemorizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        WordId = c.String(maxLength: 128),
                        Learned = c.Boolean(nullable: false),
                        Memorize = c.Boolean(nullable: false),
                        Pin = c.Boolean(nullable: false),
                        Remind = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Words", t => t.WordId)
                .Index(t => t.UserId)
                .Index(t => t.WordId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WordMemorizes", "WordId", "dbo.Words");
            DropForeignKey("dbo.WordMemorizes", "UserId", "dbo.Users");
            DropForeignKey("dbo.MyPackages", "UserId", "dbo.Users");
            DropForeignKey("dbo.MyPackages", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.Words", "WordGroupId", "dbo.WordGroups");
            DropForeignKey("dbo.WordGroups", "PackageId", "dbo.Packages");
            DropIndex("dbo.WordMemorizes", new[] { "WordId" });
            DropIndex("dbo.WordMemorizes", new[] { "UserId" });
            DropIndex("dbo.Words", new[] { "WordGroupId" });
            DropIndex("dbo.WordGroups", new[] { "PackageId" });
            DropIndex("dbo.MyPackages", new[] { "UserId" });
            DropIndex("dbo.MyPackages", new[] { "PackageId" });
            DropTable("dbo.WordMemorizes");
            DropTable("dbo.Users");
            DropTable("dbo.Words");
            DropTable("dbo.WordGroups");
            DropTable("dbo.Packages");
            DropTable("dbo.MyPackages");
            DropTable("dbo.Levels");
        }
    }
}
