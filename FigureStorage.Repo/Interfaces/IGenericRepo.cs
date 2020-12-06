namespace FigureStorage.Repo.Interfaces
{
    public interface IGenericRepo<T>
    {
        void Add(T entity);
        T Get(int id);
    }
}