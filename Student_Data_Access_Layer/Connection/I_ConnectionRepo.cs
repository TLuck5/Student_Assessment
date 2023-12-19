using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Data_Access_Layer.Connection
{
    public interface I_ConnectionRepo
    {
        public SqlConnection CreateConnection();
    }
}
