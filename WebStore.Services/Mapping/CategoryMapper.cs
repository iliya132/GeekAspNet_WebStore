using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.DTO;

namespace WebStore.Services.Mapping
{
    public static class CategoryMapper
    {
        public static CategoryDTO ToDTO(this Category Section) => Section is null ? null : new CategoryDTO
        {
            Id = Section.Id,
            Name = Section.Name
        };

        public static Category FromDTO(this CategoryDTO Section) => Section is null ? null : new Category
        {
            Id = Section.Id,
            Name = Section.Name
        };
    }
}
