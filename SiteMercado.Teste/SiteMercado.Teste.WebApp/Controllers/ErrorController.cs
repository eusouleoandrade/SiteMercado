using Microsoft.AspNetCore.Mvc;
using SiteMercado.Teste.Application.DTOs.Error;
using System.Diagnostics;

namespace SiteMercado.Teste.WebApp.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public IActionResult PageNotFound()
        {
            string originalUrl = "";

            if (HttpContext.Items.ContainsKey("originalUrl"))
                originalUrl = HttpContext.Items["originalUrl"] as string;

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, OriginalUrl = originalUrl });
        }

        [HttpGet]
        public IActionResult InternalServerError()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
