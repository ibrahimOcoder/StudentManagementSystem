namespace StudentManagementSystem.Admin.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<T> Repository<T>() where T : class;

        void Commit();

        void RollBack();
    }
}
