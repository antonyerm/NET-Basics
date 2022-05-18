using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSONSerialization
{
    class Program
    {
        static Employee employee1;
        static Employee employee2;
        static Department department;

        static void Main(string[] args)
        {
            InitializeObjects();

            // Serialize objects
            var options = new JsonSerializerOptions() { WriteIndented = true };
            var serializedEmployee1 = JsonSerializer.Serialize<Employee>(employee1, options);
            var serializedDepartment = JsonSerializer.SerializeToUtf8Bytes<Department>(department, options);
            var employeeFileName = "employee1.json";
            var departmentFileName = "department.json";
            File.WriteAllText(employeeFileName, serializedEmployee1);
            File.WriteAllBytes(departmentFileName, serializedDepartment);

            // Deserialize objects
            var jsonString = File.ReadAllText(employeeFileName);
            var someEmployee = JsonSerializer.Deserialize<Employee>(jsonString);
            jsonString = File.ReadAllText(departmentFileName);
            var someDepartment = JsonSerializer.Deserialize<Department>(jsonString);

            Console.WriteLine($"JSON Deserialized objects:");
            Console.WriteLine($"\nEmployee: name - {someEmployee.EmployeeName}");
            Console.WriteLine($"\nDepartment: name - {someDepartment.DepartmentName}");
            Console.WriteLine($"Department: employees - {someDepartment.Employees[0].EmployeeName}, {someDepartment.Employees[1].EmployeeName}");
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
    }
}
