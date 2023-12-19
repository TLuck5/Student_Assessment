using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Data_Layer.Entities
{
    public class StudentTable
    {
        public int Student_Id { get; set; }
        public string? Student_Name { get; set; } = string.Empty;
        public DateTime? Dob { get; set; }
        public string? Email { get; set; } = string.Empty;
        public int? Class_Id { get; set; }
        public string? Contact_Number { get; set; } = string.Empty;
        public string? Student_Address { get; set; } = string.Empty;
    }
}
