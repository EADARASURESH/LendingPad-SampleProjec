using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace WebApi.Models.Orders
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public List<Product> Products { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}
