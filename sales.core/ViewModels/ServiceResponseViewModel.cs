using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales.core.ViewModels
{
    public class ServiceResponseViewModel<T> where T : class
    {
        public bool success { get; set; }
        public string message { get; set; } = "";
        public IEnumerable<T> data {get;set;} = new List<T>();
    }
}
