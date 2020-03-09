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
        public IEnumerable<Brand> GetBrands() => _context.Brands;

        public BrandDto GetBrandById(int id) => _context.Brands.Find(id).ToDTO();

        public IEnumerable<Category> GetCategories() => _context.Categories;

        public CategoryDTO GetCategoriesById(int id) => _context.Categories.Find(id).ToDTO();

        public IEnumerable<ProductDto> GetProducts(ProductFilter filter)
        {
            var query = _context.Products.Include("Brand").Include("Category").AsQueryable();
            if (filter.BrandId.HasValue)
                query = query.Where(c => c.BrandId.HasValue && c.BrandId.Value.Equals(filter.BrandId.Value));
            if (filter.CategoryId.HasValue)
                query = query.Where(c => c.CategoryId.Equals(filter.CategoryId.Value));
            return query.Select(i=>new ProductDto()
            {
                Name = i.Name,
                Id = i.Id,
                ImageUrl = i.ImageUrl,
                Order = i.Order,
                Price = i.Price,
                Brand = new BrandDto()
                {
                    Id = i.BrandId.HasValue ? i.BrandId.Value : 0,
                    Name = i.Brand == null ? null : i.Brand.Name
                }
            }).ToList();
        }

        public ProductDto GetProductById(int id)
        {
            return _context.Products.Include("Brand").Include("Category").Select(i=> new ProductDto()
            {
                Name = i.Name,
                Id = i.Id,
                ImageUrl = i.ImageUrl,
                Order = i.Order,
                Price = i.Price,
                Brand = new BrandDto()
                {
                    Id = i.BrandId.HasValue ? i.BrandId.Value : 0,
                    Name = i.Brand == null ? null : i.Brand.Name
                }
            }).FirstOrDefault(p => p.Id.Equals(id));
        }


    }
}
