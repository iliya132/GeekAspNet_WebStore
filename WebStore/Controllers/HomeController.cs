using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebStore.Interfaces.Api;

namespace WebStore.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _Logger;

        public HomeController(ILogger<HomeController> Logger) => _Logger = Logger;

        [Route("Index")]
        public IActionResult Index()
        {
            _Logger.LogInformation("Запрос главной страницы!");
            return View();
        }


        [Route("Blog")]
        public IActionResult Blog()
        {
            return View();
        }

        [Route("BlogSingle")]
        public IActionResult BlogSingle()
        {
            return View();
        }

        [Route("Checkout")]
        public IActionResult Checkout()
        {
            return View();
        }

        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("Login")]

        [Route("NotFound")]
        public new IActionResult NotFound()
        {
            return View();
        }
    }
}