using Microsoft.Extensions.DependencyInjection;
using Student_Data_Access_Layer.Connection;
using Student_Data_Access_Layer.I_Repository;
using Student_Data_Access_Layer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Data_Access_Layer
{
    public static class IServiceCollection_DAL
    {
        public static void AddRepoService(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<I_ConnectionRepo,ConnectionRepo>();
            serviceDescriptors.AddScoped<I_StudentRepo, StudentRepo>();
            serviceDescriptors.AddScoped<I_UserRepo,User_Repo>();
            serviceDescriptors.AddScoped<Student_Data_Layer.Models.Student_Response_Model>();
            serviceDescriptors.AddScoped<I_ClassRepo, ClassRepo>();
        }
    }
}
