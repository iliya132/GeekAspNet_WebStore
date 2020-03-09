using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels;
using WebStore.Models.Interfaces;

namespace WebStore.ViewComponents
{
    [ViewComponent(Name ="Categories")]
    public class CategoryViewComponent :ViewComponent
    {
        private readonly IProductData _productService;

        public IViewComponentResult Invoke(string CategoryId)
        {
            var category_id = int.TryParse(CategoryId, out var id) ? id : (int?)null;

            var sections = GetCategories(category_id, out var parent_category_id);

            return View(new CategoryCompleteViewModel
            {
                Categories = sections,
                CurrentCategoryId = category_id,
                CurrentParrentCategoryId = parent_category_id
            });
        }

        public CategoryViewComponent(IProductData productService)
        {
            _productService = productService;
        }


        private List<CategoryViewModel> GetCategories(int? CategoryId, out int? ParentCategoryId)
        {
            ParentCategoryId = null;
            IEnumerable<Category> categories = _productService.GetCategories();

            List<CategoryViewModel> parentCategoriesViewModel = categories.
                Where(i => !i.ParentId.HasValue).
                Select(i=> new CategoryViewModel() 
            {
                Id = i.Id,
                Name = i.Name,
                Order = i.Order,
                ParentCategory = null
            }).ToList();


            foreach (CategoryViewModel item in parentCategoriesViewModel)
            {
                IEnumerable<Category> childCategories = categories.Where(i => i.ParentId == item.Id);

                foreach (Category childCategory in childCategories)
                {
                    if (childCategory.Id == CategoryId)
                        ParentCategoryId = item.Id;

                    item.ChildCategories.Add(new CategoryViewModel()
                    {
                        Id = childCategory.Id,
                        Name = childCategory.Name,
                        Order = childCategory.Order,
                        ParentCategory = item
                    });
                }
                item.ChildCategories = item.ChildCategories.OrderBy(i => i.Order).ToList();
            }

            parentCategoriesViewModel = parentCategoriesViewModel.OrderBy(i => i.Order).ToList();
            return parentCategoriesViewModel;

        }

    }
}
