using Dapper;
using Microsoft.Extensions.Configuration;
using Student_Data_Access_Layer.Connection;
using Student_Data_Access_Layer.I_Repository;
using Student_Data_Layer.Entities;
using Student_Data_Layer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Data_Access_Layer.Repository
{
    public class StudentRepo : I_StudentRepo
    {
        private readonly I_ConnectionRepo conn;

        public StudentRepo(I_ConnectionRepo _conn)
        {
            conn = _conn;
        }

        private StudentModel _studentlist(Student_Request_Model request)
        {
            var result = new StudentModel
            {
                Student_Id = request.Student_Id,
                Student_Name = request.Student_Name,
                Email = request.Email,
                Dob = request.Dob,
                Class_Name = request.Class_Name,
                Contact_Number = request.Contact_Number,
                Student_Address = request.Student_Address,
                Guardian_Name = request.Guardian_Name,
                Relation = request.Relation,
                Guardian_Address = request.Guardian_Address,
                Guardian_Contact_Number = request.Guardian_Contact_Number
            };
            return result;
        }
      
        public async Task<StudentModel> AddStudent(Student_Request_Model request, int User)
        {
            try
            {
                using var connection = conn.CreateConnection();
                var storedProcedure = "Add_Student";
                var parameters = new
                {
                    Student_Name = request.Student_Name,
                    Email = request.Email,
                    Dob = request.Dob,
                    Class_Name = request.Class_Name,
                    Contact_Number = request.Contact_Number,
                    Student_Address = request.Student_Address,
                    Guardian_Name = request.Guardian_Name,
                    Relation = request.Relation,
                    Guardian_Address = request.Guardian_Address,
                    Guardian_Contact_Number = request.Guardian_Contact_Number,
                    AddedById = User
                };
                await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                var studentmodel = _studentlist(request);
                return studentmodel;
                
            }catch (Exception ex)
            {
                throw new Exception("Failed to load");
            }
        }

        public async Task<StudentModel> GetStudentById(int id)
        {
            try
            {

            using var connection = conn.CreateConnection();
            var query = @"Select s.Student_Id,s.Student_Name,s.Email,s.Dob,c.Class_Name,s.Contact_Number,s.Student_Address,g.Guardian_Name,g.Relation,g.Guardian_Address,g.Guardian_Contact_Number,u.Email As AddedBy ,up.Email As UpdatedBy,s.UpdatedById from Student_table s INNER JOIN class_table c ON s.Class_Id = c.Class_Id INNER JOIN Student_guardian g ON s.Student_Id = g.Student_Id LEFT JOIN users u ON u.Id = s.AddedById LEFT JOIN users up ON s.UpdatedById = up.Id WHERE s.Student_Id = @id";
            var student = await connection.QueryFirstOrDefaultAsync<StudentModel>(query, new {id=id});
            return student;
            }catch(Exception ex)
            {
                throw new Exception($"failed to load {ex}");
            }
        }

        public async Task<List<StudentModel>> GetStudents()
        {
            try
            {

            using var connection = conn.CreateConnection();
            var query = @"Select s.Student_Id,s.Student_Name,s.Email,s.Dob,c.Class_Name,s.Contact_Number,s.Student_Address,g.Guardian_Name,g.Relation,g.Guardian_Address,g.Guardian_Contact_Number,u.Email As AddedBy ,up.Email As UpdatedBy,s.UpdatedById from Student_table s INNER JOIN class_table c ON s.Class_Id = c.Class_Id INNER JOIN Student_guardian g ON s.Student_Id = g.Student_Id LEFT JOIN users u ON u.Id = s.AddedById LEFT JOIN users up ON s.UpdatedById = up.Id";
            var students = await connection.QueryAsync<StudentModel>(query);
            return students.ToList();
            }catch(Exception ex)
            {
                throw new Exception($"failed to load {ex}");
            }
        }



        public async Task<StudentModel> UpdateStudent(Student_Request_Model request,int id, int UserId)
        {
            try
            {
            using var connection = conn.CreateConnection();
            var storedProcedure = "Update_Student";
            var parameters = new
            {
                Student_Id = id,
                Student_Name = request.Student_Name,
                Email = request.Email,
                Dob = request.Dob,
                Class_Name = request.Class_Name,
                Contact_Number = request.Contact_Number,
                Student_Address = request.Student_Address,
                Guardian_Name = request.Guardian_Name,
                Relation = request.Relation,
                Guardian_Address = request.Guardian_Address,
                Guardian_Contact_Number = request.Guardian_Contact_Number,
                UpdatedById = UserId
            };
            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            var studentmodel = _studentlist(request);
            return studentmodel;
            }catch(Exception ex)
            {
                throw new Exception($"failed to load {ex}");
            }
        }

        public async Task<int> DeleteStudent(int id)
        {
            try
            {
                using var connection = conn.CreateConnection();
                var storedProcedure = "delete_Student";
                var parameters = new { Id = id };
                var result = await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete student with ID {id}. {ex.Message}");
            }
        }

    }
}
