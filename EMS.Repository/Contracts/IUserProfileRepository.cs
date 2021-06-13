﻿using EMS.Model;
using EMS.Model.PartialClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Repository
{
    public interface IUserProfileRepository : IGenericRepository<UserProfile>
    {
        UserModel Authenticate(UserModel loginViewModel);
        List<UserProfile> GetAllEmployee();

        UserProfile GetUserById(int Id);
        UserProfile GetEmployeerByEmpId(int empId);
        void DeleteEmployee(int empId);
    }
}
