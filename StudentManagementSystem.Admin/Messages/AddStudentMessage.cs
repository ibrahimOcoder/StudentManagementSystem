using StudentManagementSystem.Admin.Entities;
using StudentManagementSystem.Messages;

namespace StudentManagementSystem.Admin.Messages
{
    public class AddStudentMessage : IntegrationBaseMessage
    {
        public string StudentName { get; set; }

        public string StudentEmail { get; set; }
    }
}
