using Student_Data_Layer.Entities;
using Student_Data_Layer.Models.User_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Data_Access_Layer.I_Repository
{
    public interface I_UserRepo
    {
        public Task<string> RegisterUser(User_Request_Model request);
        public Task<UsersTable> LoginUser(User_Request_Model request);
    }
}
