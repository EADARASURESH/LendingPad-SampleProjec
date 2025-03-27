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
    public class DeleteOrderService : IDeleteOrderService
    {
        private readonly IOrderRepository _OrderRepository;
        private readonly IIdObjectFactory<Order> _OrderFactory;
        public DeleteOrderService(IIdObjectFactory<Order> OrderFactory, IOrderRepository OrderRepository)
        {
            _OrderRepository = OrderRepository;
            _OrderFactory = OrderFactory;
        }


        public void Delete(Order Order)
        {
            _OrderRepository.Delete(Order.Id);

        }
    }
}
