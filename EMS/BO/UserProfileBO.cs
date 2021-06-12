using EMS.Model;
using EMS.Model.PartialClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EMS.BO
{
    public class UserProfileBO
    {
        EMSContext context = new EMSContext();

        public List<UserProfile> GetAllEmployee()
        {
            return context.UserProfile.Where(x=>x.FKRoleId==2).ToList();
        }

        public UserModel Authenticate(UserModel userModel)
        {
            var user = context.UserProfile.FirstOrDefault(x => x.EmailId.ToLower() == (userModel.EmailId.ToLower()));
            if (user != null)
            {
               userModel.IsValid = user.Password == userModel.Password ? true : false;
                if (userModel.IsValid)
                {
                    userModel.RoleName = context.Role.FirstOrDefault(x => x.PKRoleId == user.FKRoleId).RoleName;
                    userModel.UserProfile = user;
                }
            }
            return userModel;
        }
        public UserProfile GetUserById(int Id)
        {
            return context.UserProfile.Where(x => x.PKUserId == Id).FirstOrDefault();
        }

        public UserProfile GetEmployeerByEmpId(int empId)
        {
            return context.UserProfile.Where(x => x.EmployeeId == empId).FirstOrDefault();
        }

        public void AddEmployee(UserProfile userprofile)
        {
            context.UserProfile.Add(userprofile);
            context.SaveChanges();
        }

        public void UpdateEmployee(UserProfile userprofile)
        {
            context.Entry<UserProfile>(userprofile).State= EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteEmployee(int empId)
        {
            var employee=context.UserProfile.Find(empId);
            employee.IsActive = false;
            context.Entry<UserProfile>(employee).State = EntityState.Modified;
            //context.UserProfile.Remove(employee);
            context.SaveChanges();
        }
    }
}