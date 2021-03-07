using SiteMercado.Teste.Application.Exceptions;
using SiteMercado.Teste.Application.Interfaces;
using SiteMercado.Teste.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SiteMercado.Teste.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public void CreateProduto(Produto entity)
        {
            CheckIsNull(entity);
            CheckContainsByNome(entity);
            _repository.Add(entity);
        }

        public void DeleteProduto(Guid id)
        {
            CheckIdIsValid(id);
            var entity = GetProdutoById(id);
            CheckIsNull(entity);
            _repository.Delete(entity);
        }

        public IReadOnlyList<Produto> GetAllProdutos()
        {
            return _repository.GetAll();
        }

        public Produto GetProdutoById(Guid id)
        {
            CheckIdIsValid(id);
            return _repository.GetById(id);
        }

        public void UpdateProduto(Produto entity)
        {
            CheckIsNull(entity);
            CheckNotContainsById(entity.Id);
            CheckContainsByNome(entity);
            _repository.Update(entity);
        }

        private void CheckIsNull(Produto entity)
        {
            if (entity is null)
                throw new ServiceException($"{nameof(Produto)} inválido");
        }

        private void CheckContainsByNome(Produto entity)
        {
            var entityByNome = _repository.GetByNome(entity.Nome);

            if (!(entityByNome is null) && entity.Id != entityByNome.Id)
                throw new ServiceException($"{nameof(Produto)} já cadastrado");
        }

        private void CheckNotContainsById(Guid id)
        {
            var entityById = _repository.GetById(id);

            if (entityById is null)
                throw new ServiceException($"{nameof(Produto)} não cadastrado");
        }

        private void CheckIdIsValid(Guid id)
        {
            if (id == Guid.Empty)
                throw new ServiceException("Identificador inválido");
        }
    }
}
