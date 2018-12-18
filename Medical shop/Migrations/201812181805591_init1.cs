namespace Medical_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "isActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "ImageDirection", c => c.String());
            DropColumn("dbo.Users", "Discriminator");
            DropColumn("dbo.Products", "ImageDirection1");
            DropColumn("dbo.Products", "ImageDirection2");
            DropColumn("dbo.Products", "ImageDirection3");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ImageDirection3", c => c.String());
            AddColumn("dbo.Products", "ImageDirection2", c => c.String());
            AddColumn("dbo.Products", "ImageDirection1", c => c.String());
            AddColumn("dbo.Users", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Products", "ImageDirection");
            DropColumn("dbo.Users", "isActive");
        }
    }
}
