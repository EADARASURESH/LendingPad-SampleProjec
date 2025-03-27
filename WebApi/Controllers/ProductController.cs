using System;
using System.Linq;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Xml.Linq;
using BusinessEntities;
using Core.Services.Products;
using WebApi.Models.Products;


namespace WebApi.Controllers
{
    [RoutePrefix("Product")]
    public class ProductController : BaseApiController
    {
        private readonly ICreateProductService _createproductService;
        private readonly IDeleteProductService _deleteproductService;
        private readonly IGetProductService _getproductService;
        private readonly IUpdateProductService _updateproductService;

        public ProductController(ICreateProductService createproductService, IDeleteProductService deleteproductService, IGetProductService getproductService, IUpdateProductService updateproductService)
        {
            _createproductService = createproductService;
            _deleteproductService = deleteproductService;
            _getproductService = getproductService;
            _updateproductService = updateproductService;
        }

        [Route("{productId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage Createproduct(Guid productId, [FromBody] ProductModel model)
        {
            var product = _createproductService.Create(productId, model.Name, model.Description, model.Price, model.QuantityInStock);
            return Found(product);
        }

        [Route("{productId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage Updateproduct(Guid productId, [FromBody] ProductModel model)
        {
            var product = _getproductService.GetProduct(productId);
            if (product == null)
            {
                return DoesNotExist();
            }
            _updateproductService.Update(productId, model.Name, model.Description, model.Price, model.QuantityInStock);
            return Found(product);
        }

        [Route("{productId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage Deleteproduct(Guid productId)
        {
            var product = _getproductService.GetProduct(productId);
            if (product == null)
            {
                return DoesNotExist();
            }
            _deleteproductService.Delete(product);
            return Found();
        }

        [Route("{productId:guid}")]
        [HttpGet]
        public HttpResponseMessage Getproduct(Guid productId)
        {
            var product = _getproductService.GetProduct(productId);
            return Found(product);
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage Getproducts(int skip, int take)
        {
            var products = _getproductService.GetProducts()
                                       .Skip(skip).Take(take)
                                       .ToList();
            return Found(products);
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllproducts(Guid id)
        {
            var product = _getproductService.GetProduct(id);
            _deleteproductService.Delete(product);
            return Found();
        }

        [Route("list/name")]
        [HttpGet]
        public HttpResponseMessage GetproductsByName(string name)
        {
            var products = _getproductService.GetName(name);
            return Found(products);
        }
    }
}