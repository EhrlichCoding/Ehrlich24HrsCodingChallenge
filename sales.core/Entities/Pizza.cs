using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales.core.Entities
{
    public class Pizza
    {
        [Key]
        public string pizza_id { get; set; }
        public string pizza_type_id { get; set; } = "";
        public string size { get; set; } = "";
        public double price { get; set; }
    }
}
