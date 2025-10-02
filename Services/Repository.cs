using Microsoft.EntityFrameworkCore;
using SistemaBiblioteca.Data;
using System.Linq.Expressions;

// ReSharper disable UnusedMember.Global
namespace SistemaBiblioteca.Services
{


    // Interfaz genérica para o CRUD
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;



        // Construtor com injeção de dependência do DataContext
        public Repository(DataContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }




        // Método para adicionar uma entidade
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }




        // Método para deletar uma entidade pelo ID
        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }





        // Método para obter todas as entidades
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }





        // Método para obter uma entidade pelo ID
        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id) ??
                throw new ArgumentNullException(nameof(id), "El objeto no puede ser nulo.");
            return entity;
        }






        // Método para atualizar uma entidade
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }





        // Método para obter todas as entidades com includes
        public async Task<IEnumerable<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }


    }
}
