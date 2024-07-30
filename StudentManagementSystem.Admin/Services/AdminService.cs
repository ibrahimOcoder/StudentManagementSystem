using Newtonsoft.Json;
using StudentManagementSystem.Admin.Entities;
using StudentManagementSystem.Admin.Models;
using StudentManagementSystem.Admin.Repositories;
using StudentManagementSystem.Admin.Types;

namespace StudentManagementSystem.Admin.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddStudent(Student student)
        {
            await this._unitOfWork.Repository<Student>().Add(student);

            var eventLog = new EventLog
            {
                State = EventLogStates.Pending,
                EventBody = JsonConvert.SerializeObject(student),
                EventType = EventTypes.Add_Student
            };

            await this._unitOfWork.Repository<EventLog>().Add(eventLog);

            try
            {
                this._unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                this._unitOfWork.RollBack();
            }
        }
    }
}
