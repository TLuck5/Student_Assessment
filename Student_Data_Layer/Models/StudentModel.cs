using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Data_Layer.Models
{
    public class StudentModel
    {
        public int Student_Id { get; set; }
        public string? Student_Name { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public DateTime? Dob { get; set; }
        public string Class_Name { get; set; } = string.Empty;
        public string? Contact_Number { get; set; } = string.Empty;
        public string? Student_Address { get; set; } = string.Empty;
        public string? Guardian_Name { get; set; } = string.Empty;
        public string? Relation { get; set; } = string.Empty;
        public string? Guardian_Address { get; set; } = string.Empty;
        public string? Guardian_Contact_Number { get; set; } = string.Empty;
        public string? AddedBy { get; set; } = string.Empty;
        public string? UpdatedBy { get; set; } = string.Empty;
    }
}
