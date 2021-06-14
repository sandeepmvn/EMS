namespace EMS.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EMS.Model.EMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EMS.Model.EMSContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if (!context.Role.Any())
            {
                var userRoles = new Role[]
                {
                new Role
                {
                    PKRoleId=1,
                    RoleName="Admin"
                },
                new Role
                {
                    PKRoleId=2,
                    RoleName="Employee"
                },

                };
                foreach (Role role in userRoles)
                {
                    context.Role.Add(role);
                }
                context.SaveChanges();

            }

            if (!context.UserProfile.Any())
            {
                var user = new UserProfile[]
                {
                new UserProfile
                {
                    PKUserId=1,
                    FKRoleId=1,
                    EmployeeId=0,
                    EmailId="Admin@gmail.com",
                    Password="Admin@123",
                    FirstName="Admin",
                    LastName="test",
                    DateOfBirth=DateTime.Now,
                    PhoneNumber="9865687651",
                    Designation="Software Developer",
                    Gender="Male",
                    Address="Begumpet",
                    Workplace="Hyderabad",
                    IsActive=true
                },
                new UserProfile
                {
                    PKUserId=2,
                    FKRoleId=2,
                    EmployeeId=1,
                    EmailId="Employee@gmail.com",
                    Password="Employee@123",
                    FirstName="Employee",
                    LastName="test",
                    DateOfBirth=DateTime.Now,
                    PhoneNumber="9865687654",
                    Designation="Software Developer",
                    Gender="Male",
                    Address="Begumpet",
                    Workplace="Hyderabad",
                    IsActive=true
                },

                };
                foreach (UserProfile u in user)
                {
                    context.UserProfile.Add(u);
                }
                context.SaveChanges();

            }
        }
    }
}
