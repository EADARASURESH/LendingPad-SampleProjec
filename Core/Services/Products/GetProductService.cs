using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;

namespace Core.Services.Products
{
    [AutoRegister]
    public class GetProductService : IGetProductService
    {
        
        private readonly IProductRepository _productRepository;
        
        public GetProductService( IProductRepository productRepository)
        {
            _productRepository = productRepository;          
        }
        public Product GetName(string productName)
        {
            return _productRepository.GetByName(productName);
        }

        public Product GetProduct(Guid id)
        {
            return _productRepository.Get(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRepository.GetAll();
        }
    }
}
