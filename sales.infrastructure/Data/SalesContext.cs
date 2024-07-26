using sales.core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales.infrastructure.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext() {
            this.Database.Connection.ConnectionString = "Server=.\\SQLEXPRESS;Database=Ehrlich;Integrated Security=false;User ID=sa;pwd=112233";
        }
        public DbSet<PizzaType> PizzaTypes { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}

