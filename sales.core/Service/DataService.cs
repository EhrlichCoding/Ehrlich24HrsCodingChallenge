using CsvHelper;
using sales.core.Entities;
using sales.core.Interface.IRepository;
using sales.core.Interface.IService;
using sales.core.ViewModels;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales.core.Service
{
    public class DataService : IDataService
    {
        private readonly IPizzaTypeRepository _pizzaTypeRepository;
        private readonly IPizzaRepository _pizzaRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        public DataService(IPizzaTypeRepository pizzaTypeRepository,
            IPizzaRepository pizzaRepository,
            IOrderRepository orderRepository,
            IOrderDetailsRepository orderDetailsRepository) 
        {
            _pizzaTypeRepository = pizzaTypeRepository;
            _pizzaRepository = pizzaRepository;
            _orderDetailsRepository = orderDetailsRepository;
        }
        public async Task<ServiceResponseViewModel<PizzaType>> UploadPizzaTypeData(Stream file) 
        {
            var model = new ServiceResponseViewModel<PizzaType>();
            try
            {
                var records = Helpers.FileHelper<PizzaType>.ExtractFile(file);
                await _pizzaTypeRepository.AddRange(records);
                model.success = true;
            }
            catch(Exception e)
            {
                model.message = e.Message;
            }
            return model;
        }
        public async Task<ServiceResponseViewModel<Pizza>> UploadPizzaData(Stream file)
        {
            var model = new ServiceResponseViewModel<Pizza>();
            try
            {
                var records = Helpers.FileHelper<Pizza>.ExtractFile(file);
                await _pizzaRepository.AddRange(records);
                model.data = records;
                model.success = true;
            }
            catch (Exception e)
            {
                model.message = e.Message;
            }
            return model;
        }
        public async Task<ServiceResponseViewModel<Order>> UploadOrderData(Stream file)
        {
            var model = new ServiceResponseViewModel<Order>();
            try
            {
                var records = Helpers.FileHelper<Order>.ExtractFile(file).ToList();
                await _orderRepository.AddRange(records);
                model.data = records;
                model.success = true;
            }
            catch (Exception e)
            {
                model.message = e.Message;
            }
            return model;
        }
        public async Task<ServiceResponseViewModel<OrderDetails>> UploadOrderDetailsData(Stream file)
        {
            var model = new ServiceResponseViewModel<OrderDetails>();
            try
            {
                var records = Helpers.FileHelper<OrderDetails>.ExtractFile(file).ToList();
                await _orderDetailsRepository.AddRange(records);
                model.data = records;
                model.success = true;
            }
            catch (Exception e)
            {
                model.message = e.Message;
            }
            return model;
        }
    }
}
