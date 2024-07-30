namespace StudentManagementSystem.Student.Repositories
{
    public interface IStudentService
    {
        Task<int> AddStudent(Entities.Student Student);
        Task<int> UpdateStudent(Entities.Student Student);
        Task<int> DeleteStudent(Entities.Student Student);
    }
}
