using System.Threading.Tasks;
using FigureStorage.Models;
using FigureStorage.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FigureStorage.Repo.Repositories
{
    public class FigureRepository : IFigureRepository
    {
        private readonly IRepositoryContextFactory _factory;

        public FigureRepository(IRepositoryContextFactory factory)
        {
            _factory = factory;
        }

        public async Task AddAsync(Figure entity)
        {
            await using var context = CreateContext();
            await context.Figures.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Figure> GetAsync(int id)
        {
            await using var context = CreateContext();
            return await context.Figures.FirstOrDefaultAsync(figure => figure.Id == id);
        }

        private RepositoryContext CreateContext()
        {
            return _factory.CreateDbContext();
        }
    }
}