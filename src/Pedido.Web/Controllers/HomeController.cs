using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Pedido.Web.Controllers
{
    public class HomeController : Controller
    {
        [ResponseCache]
        public IActionResult Index()
        {
            return View();
        }
             
    }
}
