using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SiteMercado.Teste.Application.DTOs.Produto
{
    public class ProdutoRequest
    {
        [DisplayName("nome")]
        [Required(ErrorMessage = "Nome é requerido")]
        public string Nome { get; set; }

        [DisplayName("valor")]
        [Required(ErrorMessage = "Valor é requerido")]
        public decimal Valor { get; set; }

        [DisplayName("imagem")]
        [Required(ErrorMessage = "Imagem é requerida")]
        public int Imagem { get; set; }
    }
}
