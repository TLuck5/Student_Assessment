using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Data_Layer.Models.User_Model
{
    public class User_Request_Model
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string? Password { get; set; } = string.Empty;
       // [Required(ErrorMessage = "Confirm Password is required")]
       // [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string? Confirm_Password { get; set; } = string.Empty;
    }
}
