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

        public UserProfile IsUserExist(int empId,string emailId)
        {
            return ds.Where(x => x.EmployeeId == empId || x.EmailId.ToLower() == emailId.ToLower()).FirstOrDefault();
        }
        public List<UserProfileVM> GetAllEmployee()
        {
            return ds.Select(x=> new UserProfileVM() { 
                RoleId=x.FKRoleId,
                EmployeeId=x.EmployeeId,
                EmailId=x.EmailId,
                Password=x.Password,
                FirstName=x.FirstName,
                LastName=x.LastName,
                DateOfBirth=x.DateOfBirth,
                PhoneNumber=x.PhoneNumber,
                Designation=x.Designation,
                Gender=x.Gender,
                Address=x.Address,
                Workplace=x.Workplace,
                IsActive=x.IsActive
            }).Where(x => x.RoleId == 2).ToList();
        }

        public UserProfileVM GetEmployeeByEmpId(int empId)
        {
            return ds.Select(x => new UserProfileVM
            {
                RoleId = x.FKRoleId,
                EmployeeId = x.EmployeeId,
                EmailId = x.EmailId,
                Password = x.Password,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth,
                PhoneNumber = x.PhoneNumber,
                Designation = x.Designation,
                Gender = x.Gender,
                Address = x.Address,
                Workplace = x.Workplace,
                IsActive = x.IsActive
            }).FirstOrDefault(x => x.EmployeeId == empId);
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

        public void AddUserProfile(UserProfileVM userProfile)
        {
            UserProfile data = new UserProfile();
            data.FKRoleId = 2;
            data.EmployeeId = userProfile.EmployeeId;
            data.EmailId = userProfile.EmailId;
            data.Password = userProfile.Password;
            data.DateOfBirth = userProfile.DateOfBirth;
            data.Address = userProfile.Address;
            data.Designation = userProfile.Designation;
            data.FirstName = userProfile.FirstName;
            data.LastName = userProfile.LastName;
            data.Gender = userProfile.Gender;
            data.PhoneNumber = userProfile.PhoneNumber;
            data.Workplace = userProfile.Workplace;
            data.IsActive = true;
            Add(data);
        }

        public void UpdateUserProfile(UserProfileVM userProfile)
        {
            var data = ds.FirstOrDefault(x=>x.EmployeeId== userProfile.EmployeeId);
            if (data is null)
                throw new ApplicationException(" No data found with this employeeId");
            data.FKRoleId = userProfile.RoleId;
            data.EmployeeId = userProfile.EmployeeId;
            data.EmailId = userProfile.EmailId;
            data.Password = userProfile.Password;
            data.DateOfBirth = userProfile.DateOfBirth;
            data.Address = userProfile.Address;
            data.Designation = userProfile.Designation;
            data.FirstName = userProfile.FirstName;
            data.LastName = userProfile.LastName;
            data.Gender = userProfile.Gender;
            data.PhoneNumber = userProfile.PhoneNumber;
            data.Workplace = userProfile.Workplace;
            data.IsActive = true;
            Update(data);
        }

        public void UpdateEmployee(EmployeeRequestVM employeeRequest)
        {
            var data = ds.FirstOrDefault(x=>x.EmployeeId == employeeRequest.EmployeeId);
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

        public void DeleteEmployee(int empId)
        {
            var employee = ds.FirstOrDefault(x => x.EmployeeId == empId);
            employee.IsActive = false;
            Update(employee);
        }
    }
}
