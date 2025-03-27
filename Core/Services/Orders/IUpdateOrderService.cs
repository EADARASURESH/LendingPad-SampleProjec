using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface IUpdateOrderService
    {
        Order Update(Guid orderId, string customer, List<Product> products, DateTime orderDate);
    }
}
