using Student_Data_Access_Layer.I_Repository;
using Student_Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Service_Layer.Student_Services
{
    public class Student_Service : I_Student_Service
    {
        private readonly I_StudentRepo _repo;
        private readonly Student_Response_Model response;

        public Student_Service(I_StudentRepo repo,Student_Response_Model _response)
        {
            _repo = repo;
            response = _response;
        }
        public async Task<Student_Response_Model> GetStudents()
        {            
                try
                {
                    var res = await _repo.GetStudents();
                    if (!res.Any())
                    {
                        response.StatusCode = false;
                        response.ErrorMessage = "No student data is available";
                        return response;
                    }
                    response.StatusCode = true;
                    response.Message = "Successfully getting the list";
                    response.student = res;
                    return response;
                }
                catch (ArgumentNullException ex)
                {
                    response.StatusCode = false;
                    response.ErrorMessage = "Request is empty";
                    return response;
                }
                catch (Exception ex)
                {
                    response.StatusCode = false;
                    response.ErrorMessage = ex.Message;
                    return response;
                }
            }

        public async Task<Student_Response_Model> GetStudentById(int id)
        {
            try
            {
                var res = await _repo.GetStudentById(id);
                if (res.Student_Id != id)
                {
                    response.StatusCode = false;
                    response.ErrorMessage = $"Not getting the student with Id {id}";
                    return response;
                }               
                response.StatusCode = true;
                response.Message = $"Successfully Getting the Detail of Student Id {id}";
                response.student = res;
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = false;
                response.Message = ex.Message;
                return response;
            }
        }
        public async Task<Student_Response_Model> AddStudent(Student_Request_Model request, int UserId)
        {
            try
            {                
                if(request == null)
                {
                    response.StatusCode = false;
                    response.ErrorMessage = "Request is Empty";
                    return response;
                }

                var res = await _repo.AddStudent(request,UserId);

                response.StatusCode = true;
                response.Message = "Successfully Added the Student details";
                response.student = res;
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async  Task<Student_Response_Model> UpdateStudent(Student_Request_Model request, int id, int UserId)
        {
            try
            {
                if (request == null)
                {
                    response.StatusCode = false;
                    response.ErrorMessage = "Request is empty";
                    return response;
                }
                var existingStudent = await _repo.GetStudentById(id);
                if (existingStudent == null)
                {
                    response.StatusCode = false;
                    response.ErrorMessage = $"Student with ID {id} not found";
                    return response;
                }

                var res = await _repo.UpdateStudent(request, id,UserId);               
                response.StatusCode = true;
                response.Message = "Successfully updated the student details";
                response.student = res;
                return response;
            }
            catch (ArgumentNullException ex)
            {
                response.StatusCode = false;
                response.ErrorMessage = "Request or Id is empty";
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = false;
                response.ErrorMessage = ex.Message;
                return response;
            }
        }

        public async Task<Student_Response_Model> DeleteStudent(int id)
        {
            try
            {
                if (id <= 0)
                {
                    response.StatusCode = false;
                    response.ErrorMessage = "id is empty";
                }
                var existingStudent = await _repo.GetStudentById(id);
                if (existingStudent == null)
                {
                    response.StatusCode = false;
                    response.ErrorMessage = $"Student with ID {id} not found";
                }
                var res = await _repo.DeleteStudent(id);
                if (res == 0)
                {
                    response.StatusCode= false;
                    response.ErrorMessage = "Not found the id";
                }
                response.StatusCode = true;
                response.Message = $"Student with Id {id} has been deleted";               
            }
            catch(Exception ex)
            {
                response.StatusCode = false;
                response.ErrorMessage= ex.Message;
            }
            return response;
        }
    }
}
