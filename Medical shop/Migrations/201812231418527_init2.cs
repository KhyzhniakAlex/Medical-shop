namespace Medical_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Products", newName: "PrimaryProducts");
            DropForeignKey("dbo.RuleForAdmins", "UserId", "dbo.Users");
            DropIndex("dbo.RuleForAdmins", new[] { "UserId" });
            RenameColumn(table: "dbo.OrderProduct", name: "ProductId", newName: "PrimaryProductId");
            RenameIndex(table: "dbo.OrderProduct", name: "IX_ProductId", newName: "IX_PrimaryProductId");
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.PrimaryProducts", "Sale", c => c.String());
            DropColumn("dbo.Users", "isActive");
            DropColumn("dbo.RuleForAdmins", "isFree");
            DropColumn("dbo.RuleForAdmins", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RuleForAdmins", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.RuleForAdmins", "isFree", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "isActive", c => c.Boolean(nullable: false));
            DropColumn("dbo.PrimaryProducts", "Sale");
            DropColumn("dbo.Users", "Email");
            RenameIndex(table: "dbo.OrderProduct", name: "IX_PrimaryProductId", newName: "IX_ProductId");
            RenameColumn(table: "dbo.OrderProduct", name: "PrimaryProductId", newName: "ProductId");
            CreateIndex("dbo.RuleForAdmins", "UserId");
            AddForeignKey("dbo.RuleForAdmins", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.PrimaryProducts", newName: "Products");
        }
    }
}
