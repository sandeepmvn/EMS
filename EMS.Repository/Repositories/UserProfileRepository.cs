using EMS.Model;
using EMS.Model.PartialClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace EMS.Repository
{
    public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(DbContext db) : base(db)
        {

        }

        public UserModel Authenticate(UserModel loginViewModel)
        {
            var user = ds.FirstOrDefault(x => x.EmailId.ToLower() == (loginViewModel.EmailId.ToLower()));
            if (user != null)
            {
                loginViewModel.IsValid = user.Password == loginViewModel.Password ? true : false;
                if (loginViewModel.IsValid)
                {
                    loginViewModel.RoleName = _db.Set<Role>().FirstOrDefault(x => x.PKRoleId == user.FKRoleId).RoleName;
                    loginViewModel.UserProfile = user;
                }
               
            }
            return loginViewModel;
        }

        public List<UserProfile> GetAllEmployee()
        {
            return ds.Where(x => x.FKRoleId == 2).ToList();
        }

        public UserProfile GetUserById(int Id)
        {
            return ds.Where(x => x.PKUserId == Id).FirstOrDefault();
        }

        public UserProfile GetEmployeerByEmpId(int empId)
        {
            return ds.Where(x => x.EmployeeId == empId).FirstOrDefault();
        }

        public void DeleteEmployee(int empId)
        {
            var employee = ds.Find(empId);
            employee.IsActive = false;
            Update(employee);
        }
    }
}
