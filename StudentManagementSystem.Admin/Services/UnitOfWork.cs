using StudentManagementSystem.Admin.DbContexts;
using StudentManagementSystem.Admin.Repositories;

namespace StudentManagementSystem.Admin.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdminDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public UnitOfWork(AdminDbContext context)
        {
            _context = context;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (!_repositories.ContainsKey(typeof(T)))
            {
                var repositoryInstance = new Repository<T>(_context);
                _repositories.Add(typeof(T), repositoryInstance);
            }

            return (IRepository<T>)_repositories[typeof(T)];
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void RollBack()
        {
            _context.Dispose();
        }
    }
}
