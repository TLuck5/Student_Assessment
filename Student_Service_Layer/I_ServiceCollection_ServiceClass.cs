using Microsoft.Extensions.DependencyInjection;
using Student_Data_Access_Layer;
using Student_Service_Layer.Classes_Services;
using Student_Service_Layer.Student_Services;
using Student_Service_Layer.Token_Services;
using Student_Service_Layer.Users_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Service_Layer
{
    public static class I_ServiceCollection_ServiceClass
    {
        public static void AddServiceDI(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddRepoService();
            serviceDescriptors.AddScoped<I_UsersService, UserService>();
            serviceDescriptors.AddScoped<I_Student_Service, Student_Service>();
            serviceDescriptors.AddSingleton<I_JwtToken_Service, JwtToken_Service>();
            serviceDescriptors.AddScoped<I_ClassService,Class_Service>();
        }
    }
}
