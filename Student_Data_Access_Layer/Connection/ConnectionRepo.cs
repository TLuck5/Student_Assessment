using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Data_Access_Layer.Connection
{
    public class ConnectionRepo : I_ConnectionRepo
    {
        private readonly IConfiguration _configuration;

        public ConnectionRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DbConnection"));
        }
    }
}
