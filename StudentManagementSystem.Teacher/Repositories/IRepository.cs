namespace StudentManagementSystem.Teacher.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
