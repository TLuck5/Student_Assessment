using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Data_Layer.Models.User_Model
{
    public class User_Response_Model
    {
        public bool StatusCode { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public Object user { get; set; }
        public string token { get; set; }
    }
}
