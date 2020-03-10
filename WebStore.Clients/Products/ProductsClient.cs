using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WebStore.Clients.Base;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.DTO;
using WebStore.Domain.Filters;
using WebStore.Models.Interfaces;

namespace WebStore.Clients.Products
{
    public class ProductsClient : BaseClient, IProductData
    {
        public ProductsClient(IConfiguration configuration) : base(configuration)
        {
            ServiceAddress = "api/productapi";
        }

        protected sealed override string ServiceAddress { get; set; }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            var url = $"{ServiceAddress}/sections";
            var result = Get<List<CategoryDTO>>(url);
            return result;
        }

        public CategoryDTO GetCategoriesById(int id) => Get<CategoryDTO>($"{ServiceAddress}/sections/{id}");

        public IEnumerable<BrandDTO> GetBrands()
        {
            var url = $"{ServiceAddress}/brands";
            var result = Get<List<BrandDTO>>(url);
            return result;
        }

        public BrandDTO GetBrandById(int id) => Get<BrandDTO>($"{ServiceAddress}/brands/{id}");

        public PagedProductsDTO GetProducts(ProductFilter Filter = null) =>
            Post(ServiceAddress, Filter)
               .Content
               .ReadAsAsync<PagedProductsDTO>()
               .Result;

        public ProductDTO GetProductById(int id)
        {
            var url = $"{ServiceAddress}/{id}";
            var result = Get<ProductDTO>(url);
            return result;
        }


    }
}
