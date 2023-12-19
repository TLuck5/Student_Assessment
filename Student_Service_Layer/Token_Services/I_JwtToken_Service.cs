using Student_Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Service_Layer.Token_Services
{
    public interface I_JwtToken_Service
    {
        public Task<string> CreateToken(UsersTable user);
    }
}
