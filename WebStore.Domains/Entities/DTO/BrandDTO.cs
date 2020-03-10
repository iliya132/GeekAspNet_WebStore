using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Interfaces;

namespace WebStore.Domain.Entities.DTO
{
    public class BrandDTO : INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int ProductsCount { get; set; }
    }

}
