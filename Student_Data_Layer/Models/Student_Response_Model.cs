using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Data_Layer.Models
{
    public class Student_Response_Model
    {
        public bool StatusCode { get; set; }
        public string? Message { get; set; } = string.Empty;
        public string? ErrorMessage { get; set; } = string.Empty;
        public Object student { get; set; }        
    }
}
