using Microsoft.EntityFrameworkCore;
using SiteMercado.Teste.Application.Exceptions;
using SiteMercado.Teste.Application.Interfaces;
using SiteMercado.Teste.Infra.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteMercado.Teste.Infra.Persistence.Repositories
{
    public class GenericRepositoryAsync<T> : BaseRepositoryAsync, IGenericRepositoryAsync<T> where T : class
    {
        public GenericRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            try
            {
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public virtual async Task DeleteAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            try
            {
                return await _dbContext
                 .Set<T>()
                 .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dbContext.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }

        public virtual async Task UpdateAsync(T entity)
        {
            try
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(ex);
            }
        }
    }
}
