using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities;
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
        public IActionResult Shop(int? categoryId, int? brandId)
        {
            IEnumerable<Product> products = _productData.GetProducts(new ProductFilter { BrandId = brandId, CategoryId = categoryId });

            CatalogViewModel model = new CatalogViewModel()
            {
                BrandId = brandId,
                CategoryId = categoryId,
                Products = products.Select(product => new ProductViewModel()
                {
                    Id = product.Id,
                    ImageUrl = product.ImageUrl,
                    Name = product.Name,
                    Order = product.Order,
                    Price = product.Price,
                    Brand = product.Brand != null ? product.Brand.Name : string.Empty
                }).OrderBy(product => product.Order).ToList()
            };

            return View(model);
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