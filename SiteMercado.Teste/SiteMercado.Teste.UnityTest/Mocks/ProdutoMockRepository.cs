using SiteMercado.Teste.Application.Exceptions;
using SiteMercado.Teste.Application.Interfaces;
using SiteMercado.Teste.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteMercado.Teste.UnityTest.Mocks
{
    public class ProdutoMockRepository : MockRepository, IProdutoRepository
    {
        private readonly List<Produto> _data;

        public ProdutoMockRepository()
        {
            _data = _produtoData.ToList();
        }

        public Produto Add(Produto entity)
        {
            try
            {
                _data.Add(entity);
                return entity;
            }
            catch (System.Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public void Delete(Produto entity)
        {
            try
            {
                _data.Remove(entity);
            }
            catch (System.Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public IReadOnlyList<Produto> GetAll()
        {
            try
            {
                return _data;
            }
            catch (System.Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public Produto GetById(Guid id)
        {
            try
            {
                return _data.FirstOrDefault(f => f.Id == id);
            }
            catch (System.Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public Produto GetByNome(string nome)
        {
            try
            {
                return _data.FirstOrDefault(f => f.Nome == nome);
            }
            catch (System.Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public void Update(Produto entity)
        {
            try
            {
                Delete(GetById(entity.Id));
                Add(entity);
            }
            catch (System.Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }
    }
}
