using System.ComponentModel.DataAnnotations;

namespace SiteMercado.Teste.Application.DTOs.Produto
{
    public class ProdutoRequest
    {
        [Required(ErrorMessage = "Nome é requerido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Valor é requerido")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Imagem é requerida")]
        public int Imagem { get; set; }
    }
}
