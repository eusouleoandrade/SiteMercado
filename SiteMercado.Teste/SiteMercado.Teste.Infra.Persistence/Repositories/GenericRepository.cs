using Microsoft.EntityFrameworkCore;
using SiteMercado.Teste.Application.Exceptions;
using SiteMercado.Teste.Application.Interfaces;
using SiteMercado.Teste.Infra.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteMercado.Teste.Infra.Persistence.Repositories
{
    public class GenericRepository<T> : BaseRepository, IGenericRepository<T> where T : class
    {
        public GenericRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public virtual T Add(T entity)
        {
            try
            {
                _dbContext.Set<T>().Add(entity);
                _dbContext.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public virtual IReadOnlyList<T> GetAll()
        {
            try
            {
                return _dbContext.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public virtual T GetById(Guid id)
        {
            try
            {
                return _dbContext.Set<T>().Find(id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        protected void DetachLocal(Func<T, bool> predicate)
        {
            var local = _dbContext.Set<T>().Local.Where(predicate).FirstOrDefault();

            if (!(local is null))
                _dbContext.Entry(local).State = EntityState.Detached;
        }
    }
}
