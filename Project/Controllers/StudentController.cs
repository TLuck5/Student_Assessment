using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Data_Layer.Entities;
using Student_Data_Layer.Models;
using Student_Service_Layer.Student_Services;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Text.Json;

namespace Student_Project.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly I_Student_Service student_Service;

        public StudentController(I_Student_Service _student_Service)
        {
            student_Service = _student_Service;
        }

        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<List<Student_Response_Model>>> GetStudents()
        {
            var students = await student_Service.GetStudents();
            var jsonResult = JsonSerializer.Serialize(students);
            return Ok(jsonResult);
        }

        [HttpGet("GetStudentById/{id}")]
        public async Task<ActionResult<List<StudentTable>>> GetStudentById(int id)
        {
            var student = await student_Service.GetStudentById(id);
            var jsonResult = JsonSerializer.Serialize(student);
            return Ok(jsonResult);
        }

        [HttpPost("Add-Student")]
        public async Task<ActionResult<Student_Response_Model>> AddStudent(Student_Request_Model request)
        {
            //var User = this.User.Claims.FirstOrDefault(s=>s.Type==ClaimTypes.Email)?.Value;
            var UserIdClaim = this.User.Claims.FirstOrDefault(s => s.Type == ClaimTypes.NameIdentifier)?.Value;
            var UserId = UserIdClaim == null ? 0 : Convert.ToInt32(UserIdClaim);
            var student = await student_Service.AddStudent(request,UserId);
            return Ok(student);
        }

        [HttpPut("UpdateStudent/{id}")]
        public async Task<ActionResult<Student_Request_Model>> UpdateStudent(Student_Request_Model request, int id)
        {
            var UserIdClaim = this.User.Claims.FirstOrDefault(s => s.Type == ClaimTypes.NameIdentifier)?.Value;
            var UserId = UserIdClaim == null ? 0 : Convert.ToInt32(UserIdClaim);
            var student = await student_Service.UpdateStudent(request, id,UserId);
            return Ok(student);
        }

        [HttpDelete("DeleteStudent/{id}")]
        public async Task<ActionResult<Student_Response_Model>> deleteStudent(int id)
        {
            var result = await student_Service.DeleteStudent(id);
            var jsonResult = JsonSerializer.Serialize(result);
            return Ok(jsonResult);
        }
    }
}
