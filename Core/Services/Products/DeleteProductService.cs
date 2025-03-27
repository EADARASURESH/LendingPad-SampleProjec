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
    public class DeleteProductService : IDeleteProductService
    {
        
        private readonly IProductRepository _productRepository;
        private readonly IIdObjectFactory<Product> _productFactory;
        public DeleteProductService(IIdObjectFactory<Product> productFactory, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _productFactory = productFactory;
        }

      
        public void Delete(Product product)
        {
            _productRepository.Delete(product.Id);
           
        }

    }
}
