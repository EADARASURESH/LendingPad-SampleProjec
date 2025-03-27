using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Product Get(Guid id);
        Product GetByName(string name);
        IEnumerable<Product> GetAll();
        Product CreateProduct(Product product);
        Product UpdateProduct(Product product);
        void Delete(Guid id);       
    }
}
