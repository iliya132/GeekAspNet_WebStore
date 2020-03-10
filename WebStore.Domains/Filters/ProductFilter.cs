using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Filters
{
    public class ProductFilter
    {
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public List<int> Ids { get; set; }
        public int Page { get; set; }
        public int? PageSize { get; set; }
    }
}
