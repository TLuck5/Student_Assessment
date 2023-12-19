using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Data_Layer.Models.User_Model;
using Student_Service_Layer.Users_Services;
using System.Text.Json;

namespace Student_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly I_UsersService service;

        public UserController(I_UsersService _service)
        {
            service = _service;
        }

        [HttpPost("AddUser")]
        public async Task<ActionResult<User_Response_Model>> RegisterUser([FromBody]User_Request_Model request)
        {
            var result = await service.RegisterUser(request);
            var jsonResult = JsonSerializer.Serialize(result);
            return Ok(jsonResult);
        }

        [HttpPost("loginUser")]
        public async Task<ActionResult<User_Response_Model>> LoginUser([FromBody]User_Request_Model request)
        {
            var result = await service.LoginUser(request);
            var jsonResult = JsonSerializer.Serialize(result);
            return Ok(jsonResult);
        }
    }
}
