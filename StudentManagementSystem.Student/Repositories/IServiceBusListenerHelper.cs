namespace StudentManagementSystem.Student.Repositories
{
    public interface IServiceBusListenerHelper
    {
        Task ProcessMessageAsync();
    }
}
