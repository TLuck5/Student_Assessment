using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Data_Layer.Entities
{
    public class StudentGuardian
    {
        public int Guardian_Id { get; set; }
        public int? Student_Id { get; set; }
        public string? Guardian_Name { get; set; } = string.Empty;
        public string? Relation { get; set; } = string.Empty;
        public string? Guardian_Address { get; set; } = string.Empty;
        public string? Contact_Number { get; set; } = string.Empty;  
    }
}
