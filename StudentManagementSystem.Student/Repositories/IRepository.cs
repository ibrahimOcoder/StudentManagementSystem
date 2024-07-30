using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace StudentManagementSystem.Student.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);

        void Delete(T entity);

        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

        void Update(T entity);

        Task<int> SaveChanges();
    }
}
