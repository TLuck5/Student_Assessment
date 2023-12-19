using Student_Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Service_Layer.Student_Services
{
    public interface I_Student_Service
    {
        public Task<Student_Response_Model> GetStudents();
        public Task<Student_Response_Model> GetStudentById(int id);
        public Task<Student_Response_Model> AddStudent(Student_Request_Model request,int UserId);
        public Task<Student_Response_Model> UpdateStudent(Student_Request_Model request, int id,int UserId);
        public Task<Student_Response_Model> DeleteStudent(int id);
    }
}
