using Student_Data_Layer.Models.User_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Service_Layer.Users_Services
{
    public interface I_UsersService
    {
        public Task<User_Response_Model> RegisterUser(User_Request_Model request);
        public Task<User_Response_Model> LoginUser(User_Request_Model request);
    }
}
