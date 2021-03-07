using Microsoft.AspNetCore.Mvc;
using SiteMercado.Teste.Application.DTOs.Produto;
using SiteMercado.Teste.Application.Interfaces;
using SiteMercado.Teste.Application.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteMercado.Teste.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : BaseController
    {
        private readonly IProdutoService _service;

        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProdutoResponse>> Get()
        {
            return Ok(_service.GetAllProdutos().Select(s => s.ToProdutoResponse()));
        }

        [HttpGet("{id}")]
        public ActionResult<ProdutoResponse> Get(Guid id)
        {
            return Ok(_service.GetProdutoById(id).ToProdutoResponse());
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoRequest request)
        {
            _service.CreateProduto(request.ToProduto());
            return Notify("Produto cadastrado com sucesso", false);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ProdutoRequest request)
        {
            _service.UpdateProduto(request.ToProduto(id));
            return Notify("Produto atualizado com sucesso", false);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _service.DeleteProduto(id);
            return Notify("Produto removido com sucesso", false);
        }
    }
}
