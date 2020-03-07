using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.ViewComponents
{
    [ViewComponent(Name ="LoginLogout")]
    public class LoginLogoutController : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}