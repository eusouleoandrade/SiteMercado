using SiteMercado.Teste.Domain.Common;
using SiteMercado.Teste.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteMercado.Teste.Domain.Entities
{
    public class Produto : BaseEntity
    {
        public string Nome { get; private set; }

        public decimal Valor { get; private set; }

        public int Imagem { get; private set; }

        public Produto(Guid id, string nome, decimal valor, int imagem)
        {
            Id = id == null ? Guid.NewGuid() : id;
        }

        public void Validate()
        {
            IList<string> exceptions = new List<string>();

            if (String.IsNullOrEmpty(Nome) || String.IsNullOrWhiteSpace(Nome))
                exceptions.Add($"{nameof(Nome)} é requerido");

            if (Valor == Decimal.Zero)
                exceptions.Add($"{nameof(Valor)} é requerido");

            if (Imagem == Decimal.Zero)
                exceptions.Add($"{nameof(Imagem)} é requerida");

            if (exceptions.Any())
                throw new DomainException(exceptions);
        }
    }
}
