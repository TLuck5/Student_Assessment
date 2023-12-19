using Dapper;
using Student_Data_Access_Layer.Connection;
using Student_Data_Access_Layer.I_Repository;
using Student_Data_Layer.Entities;
using Student_Data_Layer.Models.User_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Data_Access_Layer.Repository
{
    public class User_Repo : I_UserRepo
    {
        private readonly I_ConnectionRepo conn;

        public User_Repo(I_ConnectionRepo _conn) {
           conn = _conn;
        }
        public async Task<string> RegisterUser(User_Request_Model request)
        {
            try
            {
                using var connection = conn.CreateConnection();
                var query = @"Insert into Users (Email,Password) Values (@Email,@Password)";
                var userAdded = await connection.ExecuteAsync(query, new { Email = request.Email, Password = request.Password });
                return $"Successfully Registered the user";
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsersTable> LoginUser(User_Request_Model request)
        {
            try
            {
                var connection = conn.CreateConnection();
                var query = @"select * from Users Where Email = @Email";
                var user = await connection.QueryFirstOrDefaultAsync<UsersTable>(query, new { Email = request.Email });
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while logging in. Please try again later.", ex);
            }
        }
    }
}
