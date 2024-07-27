namespace sales.infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alteredfieldnameonpizzatypetabl : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PizzaTypes");
            AddColumn("dbo.PizzaTypes", "pizza_type_id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.PizzaTypes", "pizza_type_id");
            DropColumn("dbo.PizzaTypes", "pizza_type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PizzaTypes", "pizza_type", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.PizzaTypes");
            DropColumn("dbo.PizzaTypes", "pizza_type_id");
            AddPrimaryKey("dbo.PizzaTypes", "pizza_type");
        }
    }
}
