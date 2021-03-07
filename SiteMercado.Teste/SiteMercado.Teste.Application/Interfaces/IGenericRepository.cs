using System;
using System.Collections.Generic;

namespace SiteMercado.Teste.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(Guid id);

        IReadOnlyList<T> GetAll();

        T Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
