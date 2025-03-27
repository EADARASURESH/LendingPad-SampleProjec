using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;
using Common;
using Core.Factories;
using Core.Services.Users;
using Data.Repositories;

namespace Core.Services.Products
{
    [AutoRegister]
    public class CreateProductService : ICreateProductService
    {
                
        private readonly IProductRepository _productRepository;
        private readonly IIdObjectFactory<Product> _productFactory;
        public CreateProductService(IIdObjectFactory<Product> productFactory,IProductRepository productRepository)
        {   _productRepository = productRepository;
            _productFactory= productFactory;
        }
        public Product Create(Guid id, string name, string Description, decimal Price, int QuantityInStock)
        {
            var product = _productFactory.Create(id);            
            _productRepository.CreateProduct(product);
            return product;
        }
    }
}
