using System.Threading.Tasks;

namespace FigureStorage.Repo.Interfaces
{
    public interface IGenericAsyncRepo<T>
    {
        Task AddAsync(T entity);
        Task<T> GetAsync(int id);
    }
}