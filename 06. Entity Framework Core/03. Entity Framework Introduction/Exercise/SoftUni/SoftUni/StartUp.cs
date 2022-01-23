using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new SoftUniContext();

            using (context)
            {
                Console.WriteLine(RemoveTown(context));
            }
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();
            
            var employees = context.Employees.ToList().OrderBy(x => x.EmployeeId);

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees.Where(e => e.Salary > 50000).Select(item => new
            {
                FirstName = item.FirstName,
                Salary = item.Salary
            });

            foreach (var employee in employees.OrderBy(e => e.FirstName))
            {
                sb.AppendLine(($"{employee.FirstName} - {employee.Salary:F2}"));
            }

            return sb.ToString();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees.Where(e => e.Department.Name == "Research and Development")
                .Select(x => new { x.FirstName, x.LastName, x.Department.Name, x.Salary })
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName);

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:F2}");
            }

            return sb.ToString();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var newAddress = new Address();
            
            newAddress.AddressText = "Vitoshka 15";
            newAddress.TownId = 4;

            context.Addresses.Add(newAddress);

            context.Employees.Where(e => e.LastName == "Nakov")
                .FirstOrDefault().Address = context.Addresses.Where(a => a.AddressText == "Vitoshka 15").FirstOrDefault();

            newAddress.Employees.Add(context.Employees.Where(e => e.LastName == "Nakov")
                .FirstOrDefault());

            context.SaveChanges();

            var employees = context.Employees.OrderByDescending(x => x.AddressId)
                .Select(e => new
                {
                    e.Address.AddressText,
                    e.AddressId
                })
                .Take(10);
                

            foreach (var employee in employees)
            {
                sb.AppendLine(employee.AddressText);
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employeesWithProjectsWithinZeroOneZeroThree = context.Employees
                .Where(e => e.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName
                    ,
                    e.LastName
                    ,
                    ManagerFirstName = e.Manager.FirstName
                    ,
                    ManagerLastName = e.Manager.LastName
                    ,
                    Projects = e.EmployeesProjects
                    .Select(p => new
                    {
                        p.Project.Name,
                        p.Project.StartDate,
                        p.Project.EndDate
                    })
                })
                .Take(10);

            foreach (var employee in employeesWithProjectsWithinZeroOneZeroThree)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    string date = project.EndDate is null ? "not finished" : project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    sb.AppendLine($"--{project.Name} - {project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {date}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count())
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Select(a => new
                {
                    a.AddressText
                    ,
                    a.Town.Name
                    ,
                    a.Employees.Count
                })
                .Take(10);

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.Name} - {address.Count} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employee147 = context.Employees.Find(147);

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

            var projects = context.EmployeesProjects
                .Select(p => new {
                p.Project.Name,
                p.EmployeeId
            })
               .Where(p => p.EmployeeId == employee147.EmployeeId)
               .OrderBy(p => p.Name);


            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var departmentsWithMoreThanFiveEmployees = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name
                    , d.Manager.FirstName
                    , d.Manager.LastName
                    , d.Employees
                });

            foreach (var department in departmentsWithMoreThanFiveEmployees)
            {
                sb.AppendLine($"{department.Name} - {department.FirstName} {department.LastName}");

                foreach (var employee in department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Select(p => new
                {
                    p.Name
                    ,
                    p.Description
                    ,
                    p.StartDate
                })
                .Take(10)
                .OrderBy(p => p.Name);

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.Name}");
                sb.AppendLine($"{project.Description}");
                sb.AppendLine($"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");

            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees.Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing" || e.Department.Name == "Information Services").ToArray();

            for (int i = 0; i < employees.Length; i++)
            {
                employees[i].Salary += employees[i].Salary * 0.12m;
            }

            foreach (var employee in employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees.Where(e => e.FirstName.StartsWith("Sa")).ToList();

            foreach (var employee in employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var project = context.Projects.Find(2);

            var employeesProjectsTwo = context.EmployeesProjects.Where(ep => ep.ProjectId == 2);
            context.EmployeesProjects.RemoveRange(employeesProjectsTwo);

            context.Projects.Remove(project);

            context.SaveChanges();

            foreach (var p in context.Projects.Take(10))
            {
                sb.AppendLine(p.Name);
            }

            return sb.ToString().ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var town = context
                .Towns
                .FirstOrDefault(x => x.Name == "Seattle");

            var addresses = context
                .Addresses
                .Include(x => x.Employees)
                .Where(x => x.Town == town)
                .ToList();

            foreach (var address in addresses)
            {
                foreach (var employee in address.Employees.Where(x => x.AddressId == address.AddressId))
                {
                    employee.AddressId = null;
                }

                context.Addresses.Remove(address);
            }

            context.Towns.Remove(town);

            context.SaveChanges();

            return $"{addresses.Count} addresses in Seattle were deleted";
        }
    }
}
