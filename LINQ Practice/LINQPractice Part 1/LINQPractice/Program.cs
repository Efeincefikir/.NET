using System;
using System.Collections.Generic;
using TCPData;
using TCPExtentions;
using System.Linq;

namespace LINQPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Employee> employees = Data.GetEmployees();

            //var filteredEmployees = employees.Where( emp => emp.AnnualSalary < 50000);

            //foreach (var employee in filteredEmployees)
            //{
            //    Console.WriteLine($"Id: {employee.Id}");
            //    Console.WriteLine($"Name: {employee.FirstName}");
            //   Console.WriteLine($"Surname: {employee.LastName}");
            //    Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
            //    Console.WriteLine($"Department Id: {employee.DepartmentId}");
            //    Console.WriteLine("");

            //}

            //List<Department> departments = Data.GetDepartments();

            //var filteredDepartment = departments.Where(emp => emp.ShortName == "HR");

            //foreach (var department in filteredDepartment)
            //{
            //    Console.WriteLine($"Id: {department.Id}");
            //    Console.WriteLine($"Short Name: {department.ShortName}");
            //    Console.WriteLine($"Long Name: {department.LongName}");

            //    Console.WriteLine("");

            //}

            List<Employee> employees = Data.GetEmployees();
            List<Department> departments = Data.GetDepartments();

            var resultList = from emp in employees
                             join dept in departments
                             on emp.DepartmentId equals dept.Id
                             select new
                             {
                                 FirstName = emp.FirstName,
                                 LastName = emp.LastName,
                                 AnnualSalary = emp.AnnualSalary,
                                 Department = dept.ShortName,


                             };

            foreach (var employee in resultList)
            {
                Console.WriteLine($"Name: {employee.FirstName}");
                Console.WriteLine($"Surname: {employee.LastName}");
                Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
                Console.WriteLine($"Department: {employee.Department}");
                Console.WriteLine("");
             }

            var AvgAnnualSalary = resultList.Average(a => a.AnnualSalary);
            var MaxAnnualSalary = resultList.Max(a => a.AnnualSalary);
            var MinAnnualSalary = resultList.Min(a => a.AnnualSalary);

            Console.WriteLine($" Average Annual Salary is: {AvgAnnualSalary}");
            Console.WriteLine($" Maximum Annual Salary is: {MaxAnnualSalary}");
            Console.WriteLine($" Minimum Annual Salary is: {MinAnnualSalary}");


        }


    }
}

