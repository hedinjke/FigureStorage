using Microsoft.EntityFrameworkCore;

namespace FigureStorage.Repo.Interfaces
{
    public interface IRepositoryContextFactory : IDbContextFactory<RepositoryContext>
    {
        
    }
}