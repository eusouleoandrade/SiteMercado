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

        public string Imagem { get; private set; }

        public Produto(string nome, decimal valor) : this(Guid.NewGuid(), nome, valor, String.Empty)
        {
        }

        public Produto(Guid id, string nome, decimal valor) : this(id, nome, valor, String.Empty)
        {
        }

        public Produto(string nome, decimal valor, string imagem)
            : this(Guid.NewGuid(), nome, valor, imagem)
        {
        }

        public Produto(Guid id, string nome, decimal valor, string imagem)
        {
            Nome = nome;
            Valor = valor;
            Imagem = imagem;
            Id = id;

            Validate();
        }

        public void Validate()
        {
            IList<string> exceptions = new List<string>();

            if (String.IsNullOrEmpty(Nome) || String.IsNullOrWhiteSpace(Nome))
                exceptions.Add($"{nameof(Nome)} é requerido");

            if (Valor == Decimal.Zero)
                exceptions.Add($"{nameof(Valor)} é requerido");

            if (exceptions.Any())
                throw new DomainException(exceptions);
        }
    }
}