using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.DTO;
using WebStore.Domain.Filters;
using WebStore.Models.Interfaces;

namespace WebStore.ServicesHosting.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase, IProductData
    {
        private readonly IProductData _productData;
        public ProductApiController(IProductData productData)
        {
            _productData = productData;
        }
        [HttpGet("sections")]
        public IEnumerable<Category> GetCategories()
        {
            return _productData.GetCategories();
        }
        [HttpGet("brands")]
        public IEnumerable<Brand> GetBrands()
        {
            return _productData.GetBrands();
        }
        [HttpPost]
        [ActionName("Post")]
        public IEnumerable<ProductDto> GetProducts([FromBody]ProductFilter filter)
        {
            return _productData.GetProducts(filter);
        }
        [HttpGet("{id}"), ActionName("Get")]
        public ProductDto GetProductById(int id)
        {
            var product = _productData.GetProductById(id);
            return product;
        }
    }
}