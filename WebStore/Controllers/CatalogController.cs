using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _Configuration;

        public CatalogController(IProductData dataContext, IConfiguration Configuration)
        {
            _productData = dataContext;
            _Configuration = Configuration;
        }
        public IActionResult Shop(int? SectionId, int? BrandId, [FromServices] IMapper Mapper, int Page = 1)
        {
            var page_size = int.TryParse(_Configuration["PageSize"], out var size) ? size : (int?)null;

            var products = _productData.GetProducts(new ProductFilter
            {
                CategoryId = SectionId,
                BrandId = BrandId,
                Page = Page,
                PageSize = page_size
            });

            return View(new CatalogViewModel
            {
                CategoryId = SectionId,
                BrandId = BrandId,
                Products = products.Products.Select(Mapper.Map<ProductViewModel>).OrderBy(p => p.Order),
                PageViewModel = new PageViewModel
                {
                    PageSize = page_size ?? 0,
                    PageNumber = Page,
                    TotalItems = products.TotalCount
                }
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