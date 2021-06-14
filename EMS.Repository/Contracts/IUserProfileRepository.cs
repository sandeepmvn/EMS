using EMS.Model;
using EMS.Model.PartialClass;
using EMS.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Repository
{
    public interface IUserProfileRepository : IGenericRepository<UserProfile>
    {
        UserModel Authenticate(UserModel loginViewModel);
        UserProfile IsUserExist(int empId, string emailId);
        List<UserProfileVM> GetAllEmployee();
        UserProfileVM GetEmployeeByEmpId(int empId);
        void AddUserProfile(UserProfileVM userProfile);
        void UpdateUserProfile(UserProfileVM userProfile);
        EmployeeRequestVM GetEmployeeForAPI(int empId);
        void UpdateEmployee(EmployeeRequestVM employeeRequest);
        void DeleteEmployee(int empId);
        
    }
}
