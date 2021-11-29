namespace WebApi_Net60.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPizzaModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "Pizza_Id", "dbo.Pizzas");
            DropIndex("dbo.Ingredients", new[] { "Pizza_Id" });
            DropPrimaryKey("dbo.Pizzas");
            AddColumn("dbo.Pizzas", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Pizzas", "Pizza_Name", c => c.String(maxLength: 128));
            AlterColumn("dbo.Pizzas", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Pizzas", "Name", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Pizzas", "Name");
            CreateIndex("dbo.Pizzas", "Pizza_Name");
            AddForeignKey("dbo.Pizzas", "Pizza_Name", "dbo.Pizzas", "Name");
            DropColumn("dbo.Ingredients", "Pizza_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredients", "Pizza_Id", c => c.Int());
            DropForeignKey("dbo.Pizzas", "Pizza_Name", "dbo.Pizzas");
            DropIndex("dbo.Pizzas", new[] { "Pizza_Name" });
            DropPrimaryKey("dbo.Pizzas");
            AlterColumn("dbo.Pizzas", "Name", c => c.String());
            AlterColumn("dbo.Pizzas", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Pizzas", "Pizza_Name");
            DropColumn("dbo.Pizzas", "Price");
            AddPrimaryKey("dbo.Pizzas", "Id");
            CreateIndex("dbo.Ingredients", "Pizza_Id");
            AddForeignKey("dbo.Ingredients", "Pizza_Id", "dbo.Pizzas", "Id");
        }
    }
}
