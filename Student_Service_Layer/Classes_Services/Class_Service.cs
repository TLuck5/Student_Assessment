using Student_Data_Access_Layer.I_Repository;
using Student_Data_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Service_Layer.Classes_Services
{
    public class Class_Service : I_ClassService
    {
        private readonly I_ClassRepo repo;

        public Class_Service(I_ClassRepo _repo)
        {
            repo = _repo;
        }

        public async Task<string> getClassByClassName(string className)
        {
            try
            {
                var res = await repo.getClassByClassName(className);
                return res;
            }catch (Exception ex)
            {
                return $"Error in getting class {ex}";
            }
        }

        public async Task<string> AddClasses(ClassTable request)
        {
            try
            {
                var checkClass = getClassByClassName(request.Class_Name);
                if (checkClass == null)
                {
                    var res = await repo.AddClasses(request);
                    return res.ToString();
                }
                else
                {
                    var res = "Class Already Exist";
                    return res;
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ClassTable>> GetClasses()
        {
            try
            {
                var res = await repo.GetClasses();
                return res.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
