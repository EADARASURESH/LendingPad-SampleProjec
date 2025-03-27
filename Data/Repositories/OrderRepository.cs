using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using BusinessEntities;
using Common;

namespace Data.Repositories
{
    [AutoRegister]
    public class OrderRepository : IOrderRepository
    {
        private readonly ObjectCache _cache = MemoryCache.Default;

        private readonly string cacheKeyPrefix = "orders_";


        public Order CreateOrder(Order product)
        {
            var cacheKey = cacheKeyPrefix + product.Id;
            if (!_cache.Contains(cacheKey))
            {
                _cache.Set(cacheKey, product, DateTimeOffset.MaxValue);
            }
            else
            {
                throw new InvalidOperationException("Product already exists in cache.");
            }
            return product;
        }


        public Order Get(Guid guid)
        {
            var cacheKey = cacheKeyPrefix + guid;
            return _cache.Get(cacheKey) as Order;
        }


        public Order UpdateOrder(Order order)
        {
            var cacheKey = cacheKeyPrefix + order.Id;
            if (_cache.Contains(cacheKey))
            {
                _cache.Set(cacheKey, order, DateTimeOffset.MaxValue);
            }
            else
            {
                throw new InvalidOperationException("Product not found in cache.");
            }
            return order;
        }
        public Order GetByName(string name)
        {
            var cacheKey = cacheKeyPrefix + name;
            return _cache.Get(cacheKey) as Order;

        }

        public IEnumerable<Order> GetAll()
        {
            List<Order> orders = new List<Order>();
            foreach (var order in _cache.ToList())
            {
                if (order.Key.Contains("order"))
                {
                    var result = order.Value as Order;
                    orders.Add(result);
                }
            }
            return orders;
        }

        public void Delete(Guid id)
        {
            var cacheKey = cacheKeyPrefix + id;
            if (_cache.Contains(cacheKey))
            {
                _cache.Remove(cacheKey);
            }
            else
            {
                throw new InvalidOperationException("Product not found in cache.");
            }
        }

        public void Save(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order entity)
        {
            foreach (var order in _cache.ToList())
            {
                if (order.Key.Contains("order"))
                {
                    _cache.Remove(order.Key);
                }

            }
        }
    }
}
