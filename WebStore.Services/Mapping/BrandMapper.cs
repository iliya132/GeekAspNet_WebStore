﻿using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.DTO;

namespace WebStore.Services.Mapping
{
    public static class BrandMapper
    {
        public static BrandDto ToDTO(this Brand Brand) => Brand is null ? null : new BrandDto
        {
            Id = Brand.Id,
            Name = Brand.Name
        };

        public static Brand FromDTO(this BrandDto Brand) => Brand is null ? null : new Brand
        {
            Id = Brand.Id,
            Name = Brand.Name
        };
    }
}
