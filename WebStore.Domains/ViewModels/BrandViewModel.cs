using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Interfaces;

namespace WebStore.Domain.ViewModels
{
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public int ProductsCount { get; set; }
    }
}
