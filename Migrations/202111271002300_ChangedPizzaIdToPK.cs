namespace WebApi_Net60.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPizzaIdToPK : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pizzas", "Pizza_Name", "dbo.Pizzas");
            DropIndex("dbo.Pizzas", new[] { "Pizza_Name" });
            RenameColumn(table: "dbo.Pizzas", name: "Pizza_Name", newName: "Pizza_Id");
            DropPrimaryKey("dbo.Pizzas");
            AlterColumn("dbo.Pizzas", "Name", c => c.String());
            AlterColumn("dbo.Pizzas", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Pizzas", "Pizza_Id", c => c.Int());
            AddPrimaryKey("dbo.Pizzas", "Id");
            CreateIndex("dbo.Pizzas", "Pizza_Id");
            AddForeignKey("dbo.Pizzas", "Pizza_Id", "dbo.Pizzas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pizzas", "Pizza_Id", "dbo.Pizzas");
            DropIndex("dbo.Pizzas", new[] { "Pizza_Id" });
            DropPrimaryKey("dbo.Pizzas");
            AlterColumn("dbo.Pizzas", "Pizza_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Pizzas", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Pizzas", "Name", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Pizzas", "Name");
            RenameColumn(table: "dbo.Pizzas", name: "Pizza_Id", newName: "Pizza_Name");
            CreateIndex("dbo.Pizzas", "Pizza_Name");
            AddForeignKey("dbo.Pizzas", "Pizza_Name", "dbo.Pizzas", "Name");
        }
    }
}
