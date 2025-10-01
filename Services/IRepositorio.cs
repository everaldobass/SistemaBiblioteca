using System.Linq.Expressions;

// ReSharper disable UnusedMemberInSuper.Global
namespace SistemaBiblioteca.Services
{
    // Métodos CRUD genéricos para cualquier entidad
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task<IEnumerable<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes);
    }
}
