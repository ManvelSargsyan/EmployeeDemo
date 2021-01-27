using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Employee.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.DataAccess.SeedData
{
    public class EmployeeSeed
    {
        public static async Task AddEmployees(IServiceProvider serviceProvider)
        {
            var employeeDbContext = serviceProvider.GetService<EmployeeDbContext>();

            employeeDbContext.Database.Migrate();

            var count = await employeeDbContext.Employees.CountAsync();

            if (count == 0)
            {
                IEnumerable<EmployeeEntity> employees = new List<EmployeeEntity>
                {
                    new EmployeeEntity
                    {
                        FirstName = "Adam",
                        LastName = "Zapel",
                        Age = 23,
                        CreateDate = DateTime.UtcNow,
                        Deleted = false,
                        Email = "adam.zapel@gmail.com",
                        PhoneNumber = "+37437777777"
                    },
                    new EmployeeEntity
                    {
                        FirstName = "Hazel",
                        LastName = "Nutt",
                        Age = 25,
                        CreateDate = DateTime.UtcNow,
                        Deleted = false,
                        Email = "hazel.nutt@gmail.com",
                        PhoneNumber = "+37437555555"
                    },
                    new EmployeeEntity
                    {
                        FirstName = "Mona",
                        LastName = "Carte",
                        Age = 34,
                        CreateDate = DateTime.UtcNow,
                        Deleted = false,
                        Email = "mona.carte@gmail.com",
                        PhoneNumber = "+37437888888"
                    },
                };

                await employeeDbContext.Employees.AddRangeAsync(employees);
                await employeeDbContext.SaveChangesAsync();
            }

        }
    }
}
