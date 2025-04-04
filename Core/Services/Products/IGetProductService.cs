﻿using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;

namespace Core.Services.Products
{
    public interface IGetProductService
    {
        Product GetProduct(Guid id);

        IEnumerable<Product> GetProducts();
        Product GetName(string productName);
    }
}
