using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales.core.Entities
{
    public class PizzaType
    {
        [Key]
        public string pizza_type { get; set; } = "";
        public string name { get; set; } = "";
        public string category { get; set; } = "";
        public string ingredients { get; set; } = "";
    }
}
