using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Entities.DTO
{
    public class PagedProductsDTO
    {
        public IEnumerable<ProductDTO> Products { get; set; }

        public int TotalCount { get; set; }
    }
}
