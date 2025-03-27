using System;
using System.Linq;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Xml.Linq;
using BusinessEntities;
using Core.Services.Orders;
using WebApi.Models.Orders;



namespace WebApi.Controllers
{
    [RoutePrefix("Order")]
    public class OrderController : BaseApiController
    {
        private readonly ICreateOrderService _createOrderService;
        private readonly IDeleteOrderService _deleteOrderService;
        private readonly IGetOrderService _getOrderService;
        private readonly IUpdateOrderService _updateOrderService;

        public OrderController(ICreateOrderService createOrderService, IDeleteOrderService deleteOrderService, IGetOrderService getOrderService, IUpdateOrderService updateOrderService)
        {
            _createOrderService = createOrderService;
            _deleteOrderService = deleteOrderService;
            _getOrderService = getOrderService;
            _updateOrderService = updateOrderService;
        }

        [Route("{orderId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder(Guid OrderId, [FromBody] OrderModel model)
        {
            var Order = _createOrderService.Create(OrderId, model.Customer, model.Products, model.OrderDate);
            return Found(Order);
        }

        [Route("{orderId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateOrder(Guid OrderId, [FromBody] OrderModel model)
        {
            var Order = _getOrderService.GetOrder(OrderId);
            if (Order == null)
            {
                return DoesNotExist();
            }
            _updateOrderService.Update(OrderId, model.Customer, model.Products, model.OrderDate);
            return Found(Order);
        }

        [Route("{orderId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(Guid OrderId)
        {
            var Order = _getOrderService.GetOrder(OrderId);
            if (Order == null)
            {
                return DoesNotExist();
            }
            _deleteOrderService.Delete(Order);
            return Found();
        }

        [Route("{OrderId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetOrder(Guid OrderId)
        {
            var Order = _getOrderService.GetOrder(OrderId);
            return Found(Order);
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetOrders(int skip, int take)
        {
            var Orders = _getOrderService.GetOrders()
                                       .Skip(skip).Take(take)
                                       .ToList();
            return Found(Orders);
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllOrders(Guid id)
        {
            var Order = _getOrderService.GetOrder(id);
            _deleteOrderService.Delete(Order);
            return Found();
        }

        [Route("list/name")]
        [HttpGet]
        public HttpResponseMessage GetOrdersByName(string name)
        {
            var Orders = _getOrderService.GetName(name);
            return Found(Orders);
        }
    }
}