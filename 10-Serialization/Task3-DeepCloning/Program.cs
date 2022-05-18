using System;
using System.Collections.Generic;

namespace Task3_DeepCloning
{
    class Program
    {
        static Employee employee1;
        static Employee employee2;
        static Department department;

        static void Main(string[] args)
        {
            InitializeObjects();
            PrintDepartment(department, "Originial object.");
            PrintDepartment(department.DeepClone(), "Deep-cloned object.");
        }

        static void InitializeObjects()
        {
            employee1 = new Employee()
            {
                EmployeeName = "John"
            };

            employee2 = new Employee()
            {
                EmployeeName = "Paul"
            };

            department = new Department()
            {
                DepartmentName = "Marketing",
                Employees = new List<Employee>()
                {
                    employee1, employee2
                }
            };
        }

        static void PrintDepartment(Department department, string header)
        {
            Console.WriteLine(header);
            Console.WriteLine($"Department name: {department.DepartmentName}");
            foreach(var employee in department.Employees)
            {
                Console.WriteLine($"Employee: {employee.EmployeeName}");
            }
            Console.WriteLine();
        }
    }
}
