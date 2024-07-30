using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Admin.Entities;
using StudentManagementSystem.Admin.Models;
using StudentManagementSystem.Admin.Repositories;
using System.Net;

namespace StudentManagementSystem.Admin.Controllers
{
    [Route("api/admin/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAdminService _adminService;

        public AdminController(IMapper iMapper, IAdminService adminService)
        {
            this._mapper = iMapper;
            this._adminService = adminService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]

        public async Task<ActionResult> AddStudent([FromBody] StudentCreateDto createDto)
        {
            try
            {
                if (createDto == null)
                {
                    return BadRequest();
                }

                var student = _mapper.Map<Student>(createDto);

                await _adminService.AddStudent(student);

                return CreatedAtRoute("", student);
            }
            catch (Exception ex)
            {
                return Conflict();
            }
        }
    }
}
