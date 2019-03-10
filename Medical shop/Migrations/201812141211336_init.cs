namespace Medical_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Date = c.String(),
                        Page = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        Date = c.String(),
                        Role = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Sum = c.Int(nullable: false),
                        Date = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        ImageDirection1 = c.String(),
                        ImageDirection2 = c.String(),
                        ImageDirection3 = c.String(),
                        Text = c.String(),
                        TypeOfProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeOfProducts", t => t.TypeOfProductId, cascadeDelete: true)
                .Index(t => t.TypeOfProductId);
            
            CreateTable(
                "dbo.TypeOfProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImageDirection = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RuleForAdmins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RulePassword = c.String(),
                        isFree = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OrderProduct",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RuleForAdmins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderProduct", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderProduct", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Products", "TypeOfProductId", "dbo.TypeOfProducts");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropIndex("dbo.OrderProduct", new[] { "ProductId" });
            DropIndex("dbo.OrderProduct", new[] { "OrderId" });
            DropIndex("dbo.RuleForAdmins", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "TypeOfProductId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropTable("dbo.OrderProduct");
            DropTable("dbo.RuleForAdmins");
            DropTable("dbo.TypeOfProducts");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
        }
    }
}
