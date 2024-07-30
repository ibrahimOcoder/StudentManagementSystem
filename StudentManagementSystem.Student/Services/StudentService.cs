using StudentManagementSystem.Student.Repositories;

namespace StudentManagementSystem.Student.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Entities.Student> _studentRepository;

        public StudentService(IRepository<Entities.Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> AddStudent(Entities.Student Student)
        {
            await _studentRepository.Add(Student);
            return await _studentRepository.SaveChanges();
        }

        public async Task<int> UpdateStudent(Entities.Student Student)
        {
            _studentRepository.Update(Student);
            return await _studentRepository.SaveChanges();
        }

        public async Task<int> DeleteStudent(Entities.Student Student)
        {
            _studentRepository.Delete(Student);
            return await _studentRepository.SaveChanges();
        }
    }
}
