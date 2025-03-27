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
    public class ProductRepository : IProductRepository
    {
        private readonly ObjectCache _cache = MemoryCache.Default;

        private readonly string cacheKeyPrefix = "Product_";


        public Product CreateProduct(Product product)
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


        public Product Get(Guid guid)
        {
            var cacheKey = cacheKeyPrefix + guid;
            return _cache.Get(cacheKey) as Product;
        }


        public Product UpdateProduct(Product product)
        {
            var cacheKey = cacheKeyPrefix + product.Id;
            if (_cache.Contains(cacheKey))
            {
                _cache.Set(cacheKey, product, DateTimeOffset.MaxValue);
            }
            else
            {
                throw new InvalidOperationException("Product not found in cache.");
            }
            return product;
        }

        // Remove a product from the cache
        public void Remove(int id)
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



        public Product GetByName(string name)
        {
            var cacheKey = cacheKeyPrefix + name;
            return _cache.Get(cacheKey) as Product;

        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> product1 = new List<Product>();
            foreach (var product in _cache.ToList())
            {
                if (product.Key.Contains("Product"))
                {
                    var result = product.Value as Product;
                    product1.Add(result);
                }
            }
            return product1;
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

        public void Save(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            foreach (var product in _cache.ToList())
            {
                _cache.Remove(product.Key);

            }
        }
    }
}
