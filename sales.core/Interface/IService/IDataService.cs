using sales.core.Entities;
using sales.core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales.core.Interface.IService
{
    public interface IDataService
    {
        Task<ServiceResponseViewModel<PizzaType>> UploadPizzaTypeData(Stream file);
        Task<ServiceResponseViewModel<Pizza>> UploadPizzaData(Stream file);
        Task<ServiceResponseViewModel<Order>> UploadOrderData(Stream file);
        Task<ServiceResponseViewModel<OrderDetails>> UploadOrderDetailsData(Stream file);
    }
}
