﻿using CsvHelper;
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
            _orderRepository = orderRepository;
        }
        public async Task<ServiceResponseViewModel<PizzaType>> UploadPizzaTypeData(Stream file) 
        {
            var model = new ServiceResponseViewModel<PizzaType>();
            try
            {
                var records = Helpers.FileHelper<PizzaType>.ExtractFile(file).ToList();
                model.data = await _pizzaTypeRepository.AddRange(records);
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
                var records = Helpers.FileHelper<Pizza>.ExtractFile(file).ToList();
                model.data = await _pizzaRepository.AddRange(records);
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
                model.data = await _orderRepository.AddRange(records);
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
                model.data = await _orderDetailsRepository.AddRange(records);
                model.success = true;
            }
            catch (Exception e)
            {
                model.message = e.Message;
            }
            return model;
        }

        public async Task<SalesDataViewModel> GetSalesData(DateTime start, DateTime end)
        {
            var model = new SalesDataViewModel();

            try
            {
                var orders = await _orderRepository.Get(i => i.date >= start && i.date <= end);
                var orderDetails = await _orderDetailsRepository.GetAll();
                var pizzas = await _pizzaRepository.GetAll();
                var pizzaTypes = await _pizzaTypeRepository.GetAll();
                var sales = orders.AsQueryable().Join(orderDetails.AsQueryable(),
                    o => o.order_id,
                    od => od.order_id,
                    (o, od) => new
                    {
                        OrderId = o.order_id,
                        PizzaId = od.pizza_id,
                        Quantity = od.quantity,
                        DateOrdered = o.date,
                    }
                    ).Join(pizzas.AsQueryable(),
                        o => o.PizzaId,
                        p => p.pizza_id,
                        (o, p) => new
                        {
                            OrderId = o.OrderId,
                            PizzaId = o.PizzaId,
                            Quantity = o.Quantity,
                            DateOrdered = o.DateOrdered,
                            PizzaTypeId = p.pizza_type_id,
                            Price = p.price,
                        }
                    ).Join(pizzaTypes.AsQueryable(),
                         o => o.PizzaTypeId,
                         pt => pt.pizza_type_id,
                         (o, pt) => new SalesDataItemViewModel
                         {
                             OrderId = o.OrderId,
                             PizzaId = o.PizzaId,
                             Quantity = o.Quantity,
                             DateOrdered = o.DateOrdered,
                             Price = o.Price,
                             PizzaName = pt.name,
                         }
                    ).ToList();

                //get sales by date
                sales = sales.GroupBy(i => i.DateOrdered).Select(n => new SalesDataItemViewModel
                {
                    OrderId = n.First().OrderId,
                    PizzaId = n.First().PizzaId,
                    Price = n.First().Price,
                    Quantity = n.First().Quantity,
                    DateOrdered = n.First().DateOrdered,
                    TotalSale = n.First().Price * n.First().Quantity
                }).ToList();
                model.data = sales;
                model.GrandTotalSale = model.data.Sum(i => i.TotalSale);
            }
            catch(Exception e)
            {
                model.message = e.Message;
            }
            return model;
        }
    }
}
