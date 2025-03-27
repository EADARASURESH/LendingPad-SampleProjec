using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntities
{
    public class Order : IdObject
    {
        public Guid OrderId { get; set; }
        public string Customer { get; set; }
        public List<Product> Products { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
      
    }
}
