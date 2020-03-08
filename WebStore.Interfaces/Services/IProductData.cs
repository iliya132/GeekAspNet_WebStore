using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.DTO;
using WebStore.Domain.Filters;

namespace WebStore.Models.Interfaces
{
    public interface IProductData
    {
        IEnumerable<Brand> GetBrands();
        BrandDto GetBrandById(int id);
        IEnumerable<Category> GetCategories();
        CategoryDTO GetCategoriesById(int id);
        IEnumerable<ProductDto> GetProducts(ProductFilter filter);
        ProductDto GetProductById(int id);
    }
}
