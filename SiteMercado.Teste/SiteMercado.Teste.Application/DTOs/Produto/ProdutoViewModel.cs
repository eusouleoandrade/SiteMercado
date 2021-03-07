using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SiteMercado.Teste.Application.DTOs.Produto
{
    public class ProdutoViewModel
    {
        [DisplayName("Cod.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é requerido")]
        public string Nome { get; set; }

        [DisplayName("Valor R$")]
        [Required(ErrorMessage = "Valor é requerido")]
        public decimal Valor { get; set; }

        public int Imagem { get; set; }
    }
}
