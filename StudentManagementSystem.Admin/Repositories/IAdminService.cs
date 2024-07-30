using StudentManagementSystem.Admin.Entities;
using StudentManagementSystem.Admin.Models;

namespace StudentManagementSystem.Admin.Repositories
{
    public interface IAdminService
    {
        Task AddStudent(Student student);
    }
}
