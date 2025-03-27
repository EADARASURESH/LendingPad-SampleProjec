using System;
using System.Collections.Generic;
using System.Text;
using Raven.Abstractions.Data;
using System.Xml.Linq;

namespace BusinessEntities
{
    public class Product : IdObject
    {
        private Guid _productId { get; set; }
        private string _name { get; set; }
        private string _description { get; set; }
        private decimal _price { get; set; }
        private int _quantityInStock { get; set; }
       

        public Guid ProductId
        {
            get => _productId;
            set => _productId = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public decimal Price
        {
            get => _price;
            set => _price = value;
        }

        public int QuantityInStock
        {
            get => _quantityInStock;
            set => _quantityInStock = value;
        }
    }
}
