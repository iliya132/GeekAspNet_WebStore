using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.ViewModels
{
    public class CategoryCompleteViewModel
    {
        public IEnumerable<CategoryViewModel> Categories { get; set; }

        public int? CurrentParrentCategoryId { get; set; }

        public int? CurrentCategoryId { get; set; }
        
    }
}
