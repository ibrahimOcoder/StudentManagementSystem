
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystem.Admin.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task Add(T entity) => await _dbSet.AddAsync(entity);

        public void Delete(T entity) => _dbSet.Remove(entity);

        public async Task<IEnumerable<T>> GetAll() => await _dbSet.ToListAsync();

        public async Task<T> GetById(int id) => await _dbSet.FindAsync(id);

        public void Update(T entity) => _dbSet.Update(entity);

        public Task<int> SaveChanges() => _context.SaveChangesAsync();
    }
}
