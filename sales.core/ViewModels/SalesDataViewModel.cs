using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales.core.ViewModels
{
    public class SalesDataViewModel : ServiceResponseViewModel<SalesDataItemViewModel>
    {
        public double GrandTotalSale { get; set; }
    }
    public class SalesDataItemViewModel
    {
        public int OrderId { get; set; }
        public string PizzaId { get; set; } = "";
        public string PizzaName { get; set; } = "";
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalSale { get; set; }
        public DateTime DateOrdered { get; set; }
    }
}
