using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class GetOrderService : IGetOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public Order GetName(string orderName)
        {
            return _orderRepository.GetByName(orderName);
        }

        public Order GetOrder(Guid id)
        {
            return _orderRepository.Get(id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orderRepository.GetAll();
        }
        

    }
}
