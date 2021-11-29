namespace PizzaApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigraton : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Pizza_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pizzas", t => t.Pizza_Id)
                .Index(t => t.Pizza_Id);
            
            CreateTable(
                "dbo.Pizzas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsGlutenFree = c.Boolean(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ingredients", "Pizza_Id", "dbo.Pizzas");
            DropIndex("dbo.Ingredients", new[] { "Pizza_Id" });
            DropTable("dbo.Pizzas");
            DropTable("dbo.Ingredients");
        }
    }
}
