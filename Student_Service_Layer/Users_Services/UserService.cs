using Student_Data_Access_Layer.I_Repository;
using Student_Data_Layer.Entities;
using Student_Data_Layer.Models.User_Model;
using Student_Service_Layer.Token_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Service_Layer.Users_Services
{
    public class UserService : I_UsersService
    {
        private readonly I_UserRepo repo;
        private readonly I_JwtToken_Service token;

        public UserService(I_UserRepo _repo, I_JwtToken_Service _token) {
            repo = _repo;
            token = _token;
        }
        public async Task<User_Response_Model> RegisterUser(User_Request_Model request)
        {
            User_Response_Model response = new User_Response_Model();
            User_Request_Model req = new User_Request_Model();

            try
            {
                if (request == null)
                {
                    response.StatusCode = false;
                    response.ErrorMessage = "request is null";
                    return response;
                }
                if(request.Password != request.Confirm_Password)
                {
                    response.StatusCode = false;
                    response.ErrorMessage = "Password and Confirm Password is not matching";
                    return response;
                }
                req.Email = request.Email;
                var pass = BCrypt.Net.BCrypt.HashPassword(request.Password);
                req.Password = pass;
                var registrationResult = await repo.RegisterUser(req);
                response.StatusCode = true;
                response.Message = registrationResult;
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = false;
                response.ErrorMessage = ex.Message;
                return response;
            }
            
        }

        public async Task<User_Response_Model> LoginUser(User_Request_Model request)
        {
            User_Response_Model response = new User_Response_Model();

            try
            {
                if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                {
                    response.StatusCode = false;
                    response.ErrorMessage = "Invalid request. Email and Password are required.";
                }
                else
                {
                    var user = await repo.LoginUser(request);
                    string trimmedProvidedPassword = request.Password.Trim();
                    if (user != null)
                    {
                        bool isValidLogin = BCrypt.Net.BCrypt.Verify(trimmedProvidedPassword, user.Password);

                        if (isValidLogin)
                        {
                            try
                            {
                                var tokenVal = await token.CreateToken(user);
                                response.StatusCode = true;
                                response.Message = "Login successful";
                                response.token = tokenVal;
                            }
                            catch (Exception tokenEx)
                            {
                                response.StatusCode = false;
                                response.ErrorMessage = $"Error generating token: {tokenEx.Message}";
                            }
                        }
                        else
                        {
                            response.StatusCode = false;
                            response.ErrorMessage = "Invalid password";
                        }
                    }
                    else
                    {
                        response.StatusCode = false;
                        response.ErrorMessage = "User not registered";
                    }
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = false;
                response.ErrorMessage = $"An error occurred while logging in. Please try again later. Details: {ex.Message}";
            }

            return response;
        }



    }
}
