using StudentManagementSystem.Admin.Entities;
using StudentManagementSystem.CommunicationConfigs;

namespace StudentManagementSystem.Admin.Messages
{
    public class AddStudentMessage : IntegrationBaseMessage
    {
        public string StudentName { get; set; }

        public string StudentEmail { get; set; }
    }
}
