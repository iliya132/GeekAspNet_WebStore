﻿using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Interfaces;

namespace WebStore.Domain.Entities.DTO
{
    public class ProductDTO : INamedEntity, IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public BrandDTO Brand { get; set; }
        public CategoryDTO Category { get; set; }
    }

}
