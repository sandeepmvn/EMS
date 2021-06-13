using EMS.Model;
using EMS.Model.PartialClass;
using EMS.Model.ViewModels;
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
            return ds.FirstOrDefault(x => x.EmployeeId == empId);
        }

        public EmployeeRequestVM GetEmployeeForAPI(int empId)
        {
           return ds.Select(x => new EmployeeRequestVM
            {
                DateOfBirth = x.DateOfBirth,
                Address = x.Address,
                Designation = x.Designation,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Gender = x.Gender,
                PhoneNumber = x.PhoneNumber,
                Workplace = x.Workplace,
                EmployeeId=x.EmployeeId
            }).FirstOrDefault(x => x.EmployeeId == empId);
        }

        public void DeleteEmployee(int empId)
        {
            var employee = ds.Find(empId);
            employee.IsActive = false;
            Update(employee);
        }

        public void UpdateEmployee(EmployeeRequestVM employeeRequest)
        {
            var data = GetEmployeerByEmpId(employeeRequest.EmployeeId);
            if (data is null)
                throw new ApplicationException(" No data found with this employeeId");
            data.DateOfBirth = employeeRequest.DateOfBirth;
            data.Address = employeeRequest.Address;
            data.Designation = employeeRequest.Designation;
            data.FirstName = employeeRequest.FirstName;
            data.LastName = employeeRequest.LastName;
            data.Gender = employeeRequest.Gender;
            data.PhoneNumber = employeeRequest.PhoneNumber;
            data.Workplace = employeeRequest.Workplace;
            Update(data);
        }
    }
}
