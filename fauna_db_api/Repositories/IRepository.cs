namespace fauna_db_api.Repositories;

public interface IRepository<T>
{
    Task<T> Add(T entity);
    Task<T> Get(int id);
    Task<IEnumerable<T>> GetAll();
    Task Update(T entity);
    Task Delete(int id);
}
