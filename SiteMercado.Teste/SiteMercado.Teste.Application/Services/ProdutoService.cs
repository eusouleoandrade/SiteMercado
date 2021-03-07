using SiteMercado.Teste.Application.Exceptions;
using SiteMercado.Teste.Application.Interfaces;
using SiteMercado.Teste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteMercado.Teste.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepositoryAsync _repository;

        public ProdutoService(IProdutoRepositoryAsync repository)
        {
            _repository = repository;
        }

        public void CreateProduto(Produto entity)
        {
            CheckIsNull(entity);
            entity.Validate();
            CheckContainsByNome(entity);
            _repository.AddAsync(entity);
        }

        public void DeleteProduto(Produto entity)
        {
            CheckIsNull(entity);
            CheckNotContains(entity);
            _repository.DeleteAsync(entity);
        }

        public Task<IReadOnlyList<Produto>> GetAllProdutos()
        {
            return _repository.GetAllAsync();
        }

        public Task<Produto> GetProdutoById(Guid id)
        {
            CheckIdIsValid(id);
            var entity = _repository.GetByIdAsync(id);
            CheckIsNull(entity.Result);
            return entity;
        }

        public void UpdateProduto(Produto entity)
        {
            CheckIsNull(entity);
            entity.Validate();
            CheckContainsByNome(entity);
            _repository.UpdateAsync(entity);
        }

        private void CheckIsNull(Produto entity)
        {
            if (entity is null)
                throw new ServiceException($"{nameof(Produto)} é requerido");
        }

        private void CheckContainsByNome(Produto entity)
        {
            var entityByNome = _repository.GetProdutoByNome(entity.Nome).Result;

            if (!(entityByNome is null) && entity.Id != entityByNome.Id)
                throw new ServiceException($"{nameof(Produto)} já cadastrado");
        }

        private void CheckNotContains(Produto entity)
        {
            if (_repository.GetByIdAsync(entity.Id) is null)
                throw new ServiceException($"{nameof(Produto)} não cadastrado");
        }

        private void CheckIdIsValid(Guid id)
        {
            if (id == Guid.Empty)
                throw new ServiceException("Identificador inválido");
        }
    }
}
