using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales.core.Entities
{
    public class OrderDetails
    {
        [Key]
        public int order_details_id { get; set; }
        public int order_id { get; set; }
        public string pizza_id { get; set; } = "";
        public int quantity { get; set; }
    }
}
