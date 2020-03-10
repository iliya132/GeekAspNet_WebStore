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
        IEnumerable<BrandDTO> GetBrands();
        BrandDTO GetBrandById(int id);
        IEnumerable<CategoryDTO> GetCategories();
        CategoryDTO GetCategoriesById(int id);
        PagedProductsDTO GetProducts(ProductFilter filter);
        ProductDTO GetProductById(int id);
    }
}
