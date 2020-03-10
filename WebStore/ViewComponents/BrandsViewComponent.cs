using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels;
using WebStore.Models.Interfaces;

namespace WebStore.ViewComponents
{
    [ViewComponent(Name = "Brands")]
    public class BrandsViewComponent :ViewComponent
    {
        private readonly IProductData _productData;

        public BrandsViewComponent(IProductData productData)
        {
            _productData = productData;
        }

        public IViewComponentResult Invoke(string BrandId) =>
            View(new BrandCompleteViewModel
            {
                Brands = GetBrands(),
                CurrentBrandId = int.TryParse(BrandId, out var id) ? id : (int?)null
            });

        private IEnumerable<BrandViewModel> GetBrands() => _productData
           .GetBrands()
           .Where(brand => brand.ProductsCount > 0)
           .Select(brand => new BrandViewModel
           {
               Id = brand.Id,
               Name = brand.Name,
               Order = brand.Order,
               ProductsCount = brand.ProductsCount,
           })
           .OrderBy(brand => brand.Order);

    }
}
