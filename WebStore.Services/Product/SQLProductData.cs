using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.DTO;
using WebStore.Domain.Filters;
using WebStore.Models.Interfaces;
using WebStore.Services.Mapping;

namespace WebStore.Models.Implementations
{
    public class SQLProductData :IProductData
    {

        WebStoreContext _context;
        public SQLProductData(WebStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<BrandDTO> GetBrands() => _context.Brands.ToDTO();

        public BrandDTO GetBrandById(int id) => _context.Brands.Find(id).ToDTO();

        public IEnumerable<CategoryDTO> GetCategories() => _context.Categories.ToDTO();

        public CategoryDTO GetCategoriesById(int id) => _context.Categories.Find(id).ToDTO();

        public PagedProductsDTO GetProducts(ProductFilter filter)
        {
            var query = _context.Products.Include("Brand").Include("Category").AsQueryable();
            if (filter.BrandId.HasValue)
                query = query.Where(c => c.BrandId.HasValue && c.BrandId.Value.Equals(filter.BrandId.Value));
            if (filter.CategoryId.HasValue)
                query = query.Where(c => c.CategoryId.Equals(filter.CategoryId.Value));
            if (filter?.Ids?.Count > 0)
                query = query.Where(product => filter.Ids.Contains(product.Id));

            var total_count = query.Count();

            if (filter?.PageSize != null)
                query = query
                   .Skip((filter.Page - 1) * (int)filter.PageSize)
                   .Take((int)filter.PageSize);

            return new PagedProductsDTO
            {
                Products = query.AsEnumerable().ToDTO(),
                TotalCount = total_count
            };
        }

        public ProductDTO GetProductById(int id) =>
            _context.Products
               .Include(p => p.Brand)
               .Include(p => p.Category)
               .FirstOrDefault(p => p.Id == id).ToDTO();


    }
}
