internal static class EnumarableCollectionExtensionMethodsHelpers
{
    public static IEnumerable<Employee> GetHighSalaryEmployees(this IEnumerable<Employee> employees)
    {

        foreach (var employee in employees)
        {
            Console.WriteLine($"Accessing the Employee: {employee.FirstName + " " + employee.LastName} \n");
            if (employee.AnnualSalary >= 50000)
                yield return employee;



        }
    }
}