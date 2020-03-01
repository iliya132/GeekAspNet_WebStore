using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Interfaces;

namespace WebStore.Domain.ViewModels
{
    public class CategoryViewModel : INamedEntity, IOrderedEntity
    {
        public CategoryViewModel()
        {
            ChildCategories = new List<CategoryViewModel>();
        }
        public int Order { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public CategoryViewModel ParentCategory { get; set; }
        public List<CategoryViewModel> ChildCategories { get; set; }
    }
}
