using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Filters;
using WebStore.Models.Interfaces;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IProductData _ProductData;
        public HomeController(IProductData ProductData) => _ProductData = ProductData;

        public IActionResult Index() => View();

        public IActionResult ProductList() => View(_ProductData.GetProducts(new ProductFilter()).Products);

        public IActionResult Edit(int? id) => View();

        public IActionResult Delete(int id) => View();

        [HttpPost, ActionName(nameof(Delete))]
        public IActionResult DeleteConfirm(int id) => RedirectToAction("ProductList");
    }
}