using Dapper;
using Student_Data_Access_Layer.Connection;
using Student_Data_Access_Layer.I_Repository;
using Student_Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Data_Access_Layer.Repository
{
    public class ClassRepo : I_ClassRepo
    {
        private readonly I_ConnectionRepo conn;

        public ClassRepo(I_ConnectionRepo _conn)
        {
            conn = _conn;
        }

        public async Task<string> getClassByClassName(string className)
        {
            try
            {
                using var connection = conn.CreateConnection();
                var query = @"Select Class_Name from Class_table Where Class_name = className";
                var res = await connection.ExecuteAsync(query);
                return res.ToString();
            }catch (Exception ex)
            {
                return $"Error in getting class {ex}";
            }
        }

        public async Task<string> AddClasses(ClassTable request)
        {
            try
            {               
                using var connection = conn.CreateConnection();
                var query = @"Insert into Class_table Values(@Class_Name)";
                var classAdded = await connection.QueryAsync(query, new {Class_name = request.Class_Name});
                return $"{request.Class_Name} is successfully added";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ClassTable>> GetClasses()
        {
            try
            {
                using var connection = conn.CreateConnection();
                var query = @"Select Class_name from Class_table";
                var classes =  await connection.QueryAsync<ClassTable>(query);
                return classes.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
