using Microsoft.AspNetCore.Mvc;
using SiteMercado.Teste.Application.DTOs.Notificacao;

namespace SiteMercado.Teste.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected virtual ActionResult Notify(string message, bool isError)
        {
            if (isError)
                return BadRequest(new NotificacaoResponse
                {
                    Status = "400",
                    Title = message,
                    Detail = string.Empty,
                    Instance = string.Empty,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
                });
            else
                return Ok(new NotificacaoResponse
                {
                    Status = "200",
                    Title = message,
                    Detail = string.Empty,
                    Instance = string.Empty,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.3.1"
                });
        }
    }
}
