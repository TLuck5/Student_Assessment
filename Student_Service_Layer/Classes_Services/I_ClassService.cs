using Student_Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Service_Layer.Classes_Services
{
    public interface I_ClassService
    {
        public Task<List<ClassTable>> GetClasses();
        public Task<string> AddClasses(ClassTable request);
        public Task<string> getClassByClassName(string className);
    }
}
