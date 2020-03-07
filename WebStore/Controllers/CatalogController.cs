using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.DTO;
using WebStore.Domain.Filters;
using WebStore.Domain.ViewModels;
using WebStore.Models.Interfaces;

namespace WebStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductData _productData;

        public CatalogController(IProductData dataContext)
        {
            _productData = dataContext;
        }
        public IActionResult Shop(int? SectionId, int? BrandId, [FromServices] IMapper Mapper)
        {
            var products = _productData.GetProducts(new ProductFilter
            {
                BrandId = BrandId
            });

            return View(new CatalogViewModel
            {
                BrandId = BrandId,
                Products = products.Select(Mapper.Map<ProductViewModel>).OrderBy(p => p.Order)
                //Products = products.Select(p => new ProductViewModel
                //{
                //    Id = p.Id,
                //    Name = p.Name,
                //    Order = p.Order,
                //    Price = p.Price,
                //    ImageUrl = p.ImageUrl
                //}).OrderBy(p => p.Order)
            });
        }

        public IActionResult ProductDetails(int id)
        {
            var product = _productData.GetProductById(id);
            if (product == null)
                return NotFound();
            return View(new ProductViewModel
            {
                Id = product.Id,
                ImageUrl = product.ImageUrl,
                Name = product.Name,
                Order = product.Order,
                Price = product.Price,
                Brand = product.Brand != null ? product.Brand.Name : string.Empty
            });
        }
    }
}