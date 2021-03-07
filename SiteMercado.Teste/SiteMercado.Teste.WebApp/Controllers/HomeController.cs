using Microsoft.AspNetCore.Mvc;

namespace SiteMercado.Teste.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
