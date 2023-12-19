using Student_Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Data_Access_Layer.I_Repository
{
    public interface I_ClassRepo
    {
        public Task<List<ClassTable>> GetClasses();
        public Task<string> AddClasses(ClassTable request);
        public Task<string> getClassByClassName(string className);
    }
}
