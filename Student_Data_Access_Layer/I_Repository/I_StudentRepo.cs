using Student_Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Data_Access_Layer.I_Repository
{
    public interface I_StudentRepo
    {
        public Task<List<StudentModel>> GetStudents();
        public Task<StudentModel> GetStudentById(int id);
        public Task<StudentModel> AddStudent(Student_Request_Model request,int User);
        public Task<StudentModel> UpdateStudent(Student_Request_Model request, int id, int UserId);
        public Task<int> DeleteStudent(int id);
    }
}
