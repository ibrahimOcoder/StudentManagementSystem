using StudentManagementSystem.Student.Repositories;

namespace StudentManagementSystem.Student.Helpers
{
    public class ServiceBusListenerHelper : IServiceBusListenerHelper
    {
        private readonly IRepository<Entities.Student> _studentRepository;

        public ServiceBusListenerHelper(IRepository<Entities.Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Task ProcessMessageAsync()
        {
            throw new NotImplementedException();
        }
    }
}
