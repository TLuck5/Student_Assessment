using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Data_Layer.Entities;
using Student_Service_Layer.Classes_Services;
using System.Text.Json;

namespace Student_Project.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly I_ClassService service;

        public ClassController(I_ClassService _service)
        {
            service = _service;
        }

        [HttpGet("getAllClasses")]
        public async Task<ActionResult<List<ClassTable>>> GetClasses()
        {
            var list = await service.GetClasses();
            var jsonList = JsonSerializer.Serialize(list);
            return Ok(jsonList);
        }

        [HttpPost("addClasses")]
        public async Task<ActionResult<string>> AddClasses(ClassTable request)
        {
            var result =  await service.AddClasses(request);
            var jsonResult = JsonSerializer.Serialize(result);
            return Ok(jsonResult);
        }
    }
}
