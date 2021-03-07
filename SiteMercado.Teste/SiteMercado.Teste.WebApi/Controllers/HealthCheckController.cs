using Microsoft.AspNetCore.Mvc;
using System;

namespace SiteMercado.Teste.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok($"{DateTime.Now:o}");
        }
    }
}
