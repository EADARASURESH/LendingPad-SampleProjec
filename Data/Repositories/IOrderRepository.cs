using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {

        Order Get(Guid id);
        IEnumerable<Order> GetAll();
        Order GetByName(string name);
        Order CreateOrder(Order order);
        Order UpdateOrder(Order order);
        void Delete(Guid id);
    }
}
