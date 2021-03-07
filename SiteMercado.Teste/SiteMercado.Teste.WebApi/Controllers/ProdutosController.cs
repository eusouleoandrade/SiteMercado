using Microsoft.AspNetCore.Mvc;
using SiteMercado.Teste.Application.DTOs.Produto;
using SiteMercado.Teste.Application.Interfaces;
using SiteMercado.Teste.Application.Mappings;
using System.Collections.Generic;
using System.Linq;

namespace SiteMercado.Teste.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProdutoResponse>> Get()
        {
            return Ok(_produtoService.GetAllProdutos().Result.Select(s => s.ToProdutoResponse()));
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoRequest request)
        {
            _produtoService.CreateProduto(request.ToProduto());
            return Ok();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
