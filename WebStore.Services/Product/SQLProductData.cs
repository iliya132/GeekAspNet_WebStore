using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL;
using WebStore.Domain.Entities;
using WebStore.Domain.Filters;
using WebStore.Models.Interfaces;

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

        public IEnumerable<Category> GetCategories() => _context.Categories;

        public IEnumerable<Product> GetProducts(ProductFilter filter)
        {
            var query = _context.Products.Include("Brand").Include("Category").AsQueryable();
            if (filter.BrandId.HasValue)
                query = query.Where(c => c.BrandId.HasValue && c.BrandId.Value.Equals(filter.BrandId.Value));
            if (filter.CategoryId.HasValue)
                query = query.Where(c => c.CategoryId.Equals(filter.CategoryId.Value));
            return query.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Include("Brand").Include("Category").FirstOrDefault(p => p.Id.Equals(id));
        }


    }
}
