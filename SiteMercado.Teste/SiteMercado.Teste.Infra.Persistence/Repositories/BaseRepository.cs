using SiteMercado.Teste.Infra.Persistence.Contexts;

namespace SiteMercado.Teste.Infra.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}
