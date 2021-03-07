using System;
using System.Text.Json.Serialization;

namespace SiteMercado.Teste.Application.DTOs.Produto
{
    public class ProdutoResponse
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("valor")]
        public decimal Valor { get; set; }

        [JsonPropertyName("imagem")]
        public int Imagem { get; set; }
    }
}
