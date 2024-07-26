using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales.core.Entities
{
    public class Order
    {
        [Key]
        public int order_id { get; set; }
        public DateTime date { get; set; }
        public TimeSpan time { get; set; }
    }
}
