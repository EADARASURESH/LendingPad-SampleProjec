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
    public class UpdateOrderService : IUpdateOrderService
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IIdObjectFactory<Order> _OrderFactory;
        public UpdateOrderService(IIdObjectFactory<Order> OrderFactory, IOrderRepository OrderRepository)
        {
            _OrderRepository = OrderRepository;
            _OrderFactory = OrderFactory;
        }

       
        public Order Update(Guid orderId, string customer, List<Product> Orders, DateTime orderDate)
        {
            var order = _OrderFactory.Create(orderId);
            _OrderRepository.UpdateOrder(order);
            return order;
        }

       
    }
}
