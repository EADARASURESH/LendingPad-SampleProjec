using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IIdObjectFactory<Order> _orderFactory;
        public CreateOrderService(IIdObjectFactory<Order> orderFactory, IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _orderFactory = orderFactory;


        }
        public Order Create(Guid orderId, string customer, List<Product> products, DateTime orderDate)
        {
            var product = _orderFactory.Create(orderId);
            _orderRepository.CreateOrder(product);
            return product;
        }
       
    }
}
