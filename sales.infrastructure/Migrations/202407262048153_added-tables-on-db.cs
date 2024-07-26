namespace sales.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtablesondb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        order_details_id = c.Int(nullable: false, identity: true),
                        order_id = c.Int(nullable: false),
                        pizza_id = c.String(),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.order_details_id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        order_id = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        time = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.order_id);
            
            CreateTable(
                "dbo.Pizzas",
                c => new
                    {
                        pizza_id = c.String(nullable: false, maxLength: 128),
                        pizza_type_id = c.String(),
                        size = c.String(),
                        price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.pizza_id);
            
            CreateTable(
                "dbo.PizzaTypes",
                c => new
                    {
                        pizza_type = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                        category = c.String(),
                        ingredients = c.String(),
                    })
                .PrimaryKey(t => t.pizza_type);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PizzaTypes");
            DropTable("dbo.Pizzas");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
        }
    }
}
