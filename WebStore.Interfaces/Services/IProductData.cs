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
        IEnumerable<Category> GetCategories();
        IEnumerable<ProductDto> GetProducts(ProductFilter filter);
        ProductDto GetProductById(int id);
    }
}
