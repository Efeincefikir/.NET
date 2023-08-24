using System.Collections.Generic;
using System.Linq;
using System.Transactions;

class Program
{
    static void Main(string[] args)
    {

        List<Employee> employees = Data.GetEmployees();
        List<Department> departments = Data.GetDepartments();

        // --------Method Syntax Example----------

        //var results = employees.Select(e => new
        //{
        //    FullName = e.FirstName + " " + e.LastName,
        //    AnnualSalary = e.AnnualSalary,
        //}
        //).Where( e=> e.AnnualSalary > 50000);

        //foreach( var emp in results  )
        //{
        //    Console.WriteLine( emp.FullName );
        //    Console.WriteLine(emp.AnnualSalary );
        //    Console.WriteLine();

        //}

        // --------Query Syntax Example---------

        //var results = from emp in employees
        //              where emp.AnnualSalary >= 50000
        //              select new

        //              {
        //                  FullName = emp.FirstName + " " + emp.LastName,
        //                  AnnualSalary = emp.AnnualSalary,
        //              };
        //employees.Add(new Employee
        //{
        //    Id = 5,
        //    FirstName = "Leblebi",
        //    LastName = "Boye",
        //    AnnualSalary = 100000.20m,
        //    IsManager = true,
        //    DepartmentId = 2
        //}
        //);

        //foreach (var emp in results)
        //{
        //    Console.WriteLine( emp.FullName );
        //    Console.WriteLine(emp.AnnualSalary );
        //    Console.WriteLine();

        //}

        //        -------Deffered Execution Example --------

        //        var results = from emp in employees.GetHighSalaryEmployees()
        //                      select new
        //                      {
        //                          FullName = emp.FirstName + " " + emp.LastName,
        //                          AnnualSalary = emp.AnnualSalary
        //                      };
        //        employees.Add(new Employee
        //        {
        //            Id = 5,
        //            FirstName = "Leblebi",
        //            LastName = "Boye",
        //            AnnualSalary = 100000.20m,
        //            IsManager = true,
        //            DepartmentId = 2
        //        }
        //);



        //        foreach (var emp in results)
        //        {
        //            Console.WriteLine(emp.FullName);
        //            Console.WriteLine(emp.AnnualSalary);
        //            Console.WriteLine();

        //        }
        //        ----- Immediate Execution Example -----

        //var results = (from emp in employees.GetHighSalaryEmployees()
        //               select new
        //               {
        //                   FullName = emp.FirstName + " " + emp.LastName,
        //                   AnnualSalary = emp.AnnualSalary
        //               }).ToList();


        //employees.Add(new Employee
        //{
        //    Id = 5,
        //    FirstName = "Leblebi",
        //    LastName = "Boye",
        //    AnnualSalary = 100000.20m,
        //    IsManager = true,
        //    DepartmentId = 2
        //}
        //);



        //foreach (var emp in results)
        //{
        //    Console.WriteLine(emp.FullName);
        //    Console.WriteLine(emp.AnnualSalary);
        //    Console.WriteLine();



        //}

        // ----Join Operator Example Method Syntax ----

        //var results = departments.Join(employees,
        //    department => department.Id,
        //    employee => employee.DepartmentId,
        //    (department, employee) => new
        //    {
        //        FullName = employee.FirstName + " " + employee.LastName,
        //        AnnualSalary = employee.AnnualSalary,
        //        DepartmentName = department.LongName,
        //        DepartmentShortName = department.ShortName,
        //    }
        //    );
        //foreach (var emp in results)
        //{
        //    Console.WriteLine(emp.FullName);
        //    Console.WriteLine(emp.AnnualSalary);
        //    Console.WriteLine(emp.DepartmentName);
        //    Console.WriteLine(emp.DepartmentShortName);
        //    Console.WriteLine();
        //}


        // ---- Join Operator Example Query Syntax ----

        //var results = from emp in employees
        //              join dept in departments
        //              on emp.DepartmentId equals dept.Id
        //              select new
        //              {
        //                  FullName = emp.FirstName + " " + emp.LastName,
        //                  AnnualSalary = emp.AnnualSalary,
        //                  DepartmentName = dept.LongName,
        //                  DepartmentShortName = dept.ShortName,
        //              };

        //foreach (var emp in results)
        //{
        //    Console.WriteLine(emp.FullName);
        //    Console.WriteLine(emp.AnnualSalary);
        //    Console.WriteLine(emp.DepartmentName);
        //    Console.WriteLine(emp.DepartmentShortName);
        //    Console.WriteLine();
        //}


        // ----Group Join Operator Example Method Syntax ----

        //var result = departments.Join(employees,
        //    dept => dept.Id,
        //    emp => emp.DepartmentId,

        //    (dept, employeesGroup) => new
        //    {
        //        EmployeesA = employeesGroup,
        //        DepartmentName = dept.LongName
        //    });

        //foreach (var item in result)
        //{
        //    Console.WriteLine($"Department: {item.DepartmentName}");

        //    foreach (var emp in item.EmployeesA)
        //    {
        //        Console.WriteLine($"{emp.FirstName} {emp.LastName}");
        //    }
        //}

        // ----Group Join Operator Example Query Syntax ----

        var result =  from dept in departments
                      join emp in employees
                      on dept.Id equals emp.DepartmentId
                      into employeeGroup
                      select new
                      {
                          EmployeesA = employeeGroup,
                          DepartmentName = dept.LongName
                      };

        foreach (var item in result)
        {
            Console.WriteLine($"Department: {item.DepartmentName}");

            foreach (var emp in item.EmployeesA)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName}");
            }
        }

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
            DepartmentId = 1
        };
        employees.Add(employee);
        employee = new Employee
        {
            Id = 2,
            FirstName = "Sarah",
            LastName = "Jameson",
            AnnualSalary = 80000.1m,
            IsManager = true,
            DepartmentId = 2
        };
        employees.Add(employee);
        employee = new Employee
        {
            Id = 3,
            FirstName = "Douglas",
            LastName = "Roberts",
            AnnualSalary = 40000.2m,
            IsManager = false,
            DepartmentId = 2
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

}

