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
            this.Database.Connection.ConnectionString = "Server=.\\SQLEXPRESS;Database=ehrlich;Integrated Security=false;User ID=sa;pwd=112233";
        }


    }
}
