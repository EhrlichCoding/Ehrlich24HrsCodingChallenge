using Microsoft.AspNetCore.Mvc;
using sales.core.Entities;
using sales.core.Interface.IService;
using sales.core.ViewModels;

namespace sales.outer.Controllers
{
    public class SalesDataController : Controller
    {
        private readonly IDataService _dataService;
        public SalesDataController(IDataService dataService) 
        {
            _dataService = dataService;
        }
        [HttpPost("UploadOrderDetailsData")]
        public async Task<ServiceResponseViewModel<OrderDetails>> UploadOrderDetailsData([FromForm] IFormFileCollection file)
        {
            var response = await _dataService.UploadOrderDetailsData(file[0].OpenReadStream());
            return response;
        }
        [HttpPost("UploadOrderData")]
        public async Task<ServiceResponseViewModel<Order>> UploadOrderData([FromForm] IFormFileCollection file)
        {
            var response = await _dataService.UploadOrderData(file[0].OpenReadStream());
            return response;
        }
        [HttpPost("UploadPizzaTypeData")]
        public async Task<ServiceResponseViewModel<PizzaType>> UploadPizzaTypeData([FromForm] IFormFileCollection file)
        {
            var response = await _dataService.UploadPizzaTypeData(file[0].OpenReadStream());
            return response;
        }
        [HttpPost("UploadPizzaData")]
        public async Task<ServiceResponseViewModel<Pizza>> UploadPizzaData([FromForm] IFormFileCollection file)
        {
            var response = await _dataService.UploadPizzaData(file[0].OpenReadStream());
            return response;
        }
    }
}
