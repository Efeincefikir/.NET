using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPData
{
    public static class Data
    {
        public static List<Employee> GetEmployees()

        {
            var employees = new List<Employee>();
            var employee = new Employee
            {
                Id = 1,
                FirstName = "Efe",
                LastName = "Incefikir",
                AnnualSalary = 40000,
                IsManager = true,
                DepartmentId = 1,

            };

            employees.Add(employee);


            employee = new Employee
            {
                Id = 2,
                FirstName = "Lebüs",
                LastName = "Mebüs",
                AnnualSalary = 50000,
                IsManager = false,
                DepartmentId = 2,

            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 3,
                FirstName = "Tankut",
                LastName = "Basvara",
                AnnualSalary = 30000,
                IsManager = false,
                DepartmentId = 3,

            };
            employees.Add(employee);


            employee = new Employee
            {
                Id = 4,
                FirstName = "Bankut",
                LastName = "Tasvara",
                AnnualSalary = 20000,
                IsManager = true,
                DepartmentId = 3,

            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 5,
                FirstName = "Leblebi",
                LastName = "Boy",
                AnnualSalary = 1020000,
                IsManager = true,
                DepartmentId = 4,

            };
            employees.Add(employee);


            return employees;
        }

        public static List<Department> GetDepartments() {
        List<Department> departments = new List<Department>();
        Department department = new Department() {

            Id = 1,
            ShortName = "HR",
            LongName = "Human Resources",
        };
        departments.Add(department);

            department = new Department()
            {

                Id = 2,
                ShortName = "FN",
                LongName = "Finance",
            };
            departments.Add(department);

            department = new Department()
            {

                Id = 3,
                ShortName = "TE",
                LongName = "Technology",
            };
            departments.Add(department);

            department = new Department()
            {

                Id = 4,
                ShortName = "RND",
                LongName = "Research and Development",
            };
            departments.Add(department);

            return departments;

        }


    }
}
