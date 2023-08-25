using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LINQExamples_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = Data.GetEmployees();
            List<Department> departments = Data.GetDepartments();



            //Orderby Operator

            //var results = from emp in employees
            //              join dept in departments
            //              on emp.DepartmentId equals dept.Id
            //              orderby emp.DepartmentId, emp.AnnualSalary descending
            //              select new
            //              {
            //                  Id = emp.Id,
            //                  FirstName = emp.FirstName,
            //                  LastName = emp.LastName,
            //                  AnnualSalary = emp.AnnualSalary,
            //                  DepartmentId = emp.DepartmentId,
            //                  DepartmentName = dept.LongName
            //              };
            //foreach (var item in results)
            //    Console.WriteLine($"First Name: {item.FirstName,-10} \t Last Name: {item.LastName} \t Annual Salary: {item.AnnualSalary} \t Department Name: {item.DepartmentName}");

            // In the Method Syntax OrderByDescending, ThenBy and ThenByDescending methods are also required.

            // Grouping Operators
            // GroupBy

            //var result = from emp in employees
            //             group emp by emp.DepartmentId;

            //foreach(var EmpGroup in result)
            //{
            //    Console.WriteLine($"Department ID: {EmpGroup.Key} ");

            //    foreach ( var item in EmpGroup)
            //    {
            //        Console.WriteLine($" Name: {item.FirstName} {item.LastName}");

            //    }
            //}

            ////ToLookup Operator
            ///
            ////var groupResult = employees.OrderBy(o => o.DepartmentId).ToLookup(e => e.DepartmentId);
            //var groupResult = employees.ToLookup(e => e.DepartmentId);

            //foreach (var empGroup in groupResult)
            //{
            //    Console.WriteLine($"Department Id: {empGroup.Key}");

            //    foreach (Employee emp in empGroup)
            //    {
            //        Console.WriteLine($"\tEmployee Fullname: {emp.FirstName} {emp.LastName}");
            //    }

            //}

            //ToLookup shares the same functionality with GroupBy operator. Only Difference is GroupBy is Deffered, While ToLookUp is Immediate

            //Quantifier Operators

            // All and Any Operators

            //var annualSalaryCompare = 40000;

            //bool isTrueAll = employees.All(e => e.AnnualSalary > annualSalaryCompare);
            //if (isTrueAll)
            //{
            //    Console.WriteLine($"All employee annual salaries are above {annualSalaryCompare}");
            //}
            //else
            //{
            //    Console.WriteLine($"Not all employee annual salaries are above {annualSalaryCompare}");
            //}

            //bool isTrueAny = employees.Any(e => e.AnnualSalary > annualSalaryCompare);
            //if (isTrueAny)
            //{
            //    Console.WriteLine($"At least one employee has an annual salary above {annualSalaryCompare}");
            //}
            //else
            //{
            //    Console.WriteLine($"No employees have an annual salary above {annualSalaryCompare}");
            //}

            // Contains Operator

            //Employee searchEmployee = new Employee
            //{
            //    Id = 1,
            //    FirstName = "Bob",
            //    LastName = "Jones",
            //    AnnualSalary = 60000.3m,
            //    IsManager = true,
            //    DepartmentId = 2
            //};


            //bool ContainsEmployee = employees.Contains(searchEmployee, new EmployeeComparer());

            //if (ContainsEmployee)
            //{
            //    Console.WriteLine($" The Employee {searchEmployee.FirstName} {searchEmployee.LastName} is in the database");
            //}

            //else Console.WriteLine($" The Employee {searchEmployee.FirstName} {searchEmployee.LastName} is not in the database");


            // OfType Operator

            var mixedType = Data.GetHeterogeneousDataCollection();

            //var result = from s in mixedType.OfType<String>()
            //             select s;

            //foreach ( var item in  result )
            //{
            //    Console.WriteLine( item );
            //}

            //var result = from s in mixedType.OfType<Employee>()
            //             select s;

            //foreach (var item in result)
            //{
            //    Console.WriteLine($" ID: {item.Id}  Name: {item.FirstName} {item.LastName}");
            //}

            //var result = from s in mixedType.OfType<Department>()
            //             select s;

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Department ID: {item.Id}  Department Name: {item.LongName}");
            //}

            // ElementAt and ElementAtOrDefault Operators

            //var emp = employees.ElementAtOrDefault(12);

            //if (emp != null)
            //{
            //    Console.WriteLine($"{emp.Id,-5} {emp.FirstName,-10} {emp.LastName,-10}");
            //}
            //else
            //{
            //    Console.WriteLine("This employee record does not exist within the collection");
            //}

            // If there is no such element at the specified index, ElementAt operator will throw a OutOfBounds Exception
            // ElementAtOrDefault will instead return a null value, as null value is the default value for all user created data types

            // First, FirstOrDefault, Last, LastOrDefault Operators


            //List<int> integerList = new List<int> {3,13,23,17,26,87};

            ////int result = integers.First(i => i % 2 == 0);
            //// int result = integers.FirstOrDefault(i => i % 2 == 0);
            //int result = integers.LastOrDefault(i => i % 2 == 0);

            //if (result != 0)
            //{
            //    Console.WriteLine(result);
            //}
            //else
            //{
            //    Console.WriteLine("There are no even numbers in the collection");
            //}

            // If there is no such element at the specified index, First and Last operators will throw a InvalidOperation Exception
            // FirstOrDefault and LastOrDefault will instead return a the default value of the data type.


            //Single, SingleOrDefault Operators

            var emp = employees.SingleOrDefault();

            if (emp != null)
            {
                Console.WriteLine($"{emp.Id,-5} {emp.FirstName,-10} {emp.LastName,-10}");
            }
            else
            {
                Console.WriteLine("This employee does not exist within the collection");
            }
            Console.ReadKey();



        }


    }

    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            if (x.Id == y.Id && x.FirstName.ToLower() == y.FirstName.ToLower() && x.LastName.ToLower() == y.LastName.ToLower())
            {
                return true;
            }
            else return false;
        }

        public int GetHashCode([DisallowNull] Employee obj)
        {
            return obj.Id.GetHashCode();
        }
    }


    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public bool IsManager { get; set; }
        public int DepartmentId { get; set; }
    }
    public class Department
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
    }
    public static class Data
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            Employee employee = new Employee
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Jones",
                AnnualSalary = 60000.3m,
                IsManager = true,
                DepartmentId = 2
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 2,
                FirstName = "Sarah",
                LastName = "Jameson",
                AnnualSalary = 80000.1m,
                IsManager = true,
                DepartmentId = 3
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 3,
                FirstName = "Douglas",
                LastName = "Roberts",
                AnnualSalary = 40000.2m,
                IsManager = false,
                DepartmentId = 1
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 4,
                FirstName = "Jane",
                LastName = "Stevens",
                AnnualSalary = 30000.2m,
                IsManager = false,
                DepartmentId = 3
            };
            employees.Add(employee);

            return employees;
        }

        public static List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            Department department = new Department
            {
                Id = 1,
                ShortName = "HR",
                LongName = "Human Resources"
            };
            departments.Add(department);
            department = new Department
            {
                Id = 2,
                ShortName = "FN",
                LongName = "Finance"
            };
            departments.Add(department);
            department = new Department
            {
                Id = 3,
                ShortName = "TE",
                LongName = "Technology"
            };
            departments.Add(department);

            return departments;
        }

        public static ArrayList GetHeterogeneousDataCollection()
        {
            ArrayList arrayList = new ArrayList();

            arrayList.Add(100);
            arrayList.Add("Bob Jones");
            arrayList.Add(2000);
            arrayList.Add(3000);
            arrayList.Add("Bill Henderson");
            arrayList.Add(new Employee { Id = 6, FirstName = "Jennifer", LastName = "Dale", AnnualSalary = 90000, IsManager = true, DepartmentId = 1 });
            arrayList.Add(new Employee { Id = 7, FirstName = "Dane", LastName = "Hughes", AnnualSalary = 60000, IsManager = false, DepartmentId = 2 });
            arrayList.Add(new Department { Id = 4, ShortName = "MKT", LongName = "Marketing" });
            arrayList.Add(new Department { Id = 5, ShortName = "R&D", LongName = "Research and Development" });
            arrayList.Add(new Department { Id = 6, ShortName = "PRD", LongName = "Production" });

            return arrayList;
        }

    }

}