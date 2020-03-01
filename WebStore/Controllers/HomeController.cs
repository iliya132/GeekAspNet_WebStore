using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
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

        [Route("Cart")]
        public IActionResult Cart()
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