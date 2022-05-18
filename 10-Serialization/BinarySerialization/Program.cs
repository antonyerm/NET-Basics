using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization
{
    class Program
    {
        static Employee employee1;
        static Employee employee2;
        static Department department;

        static void Main(string[] args)
        {
            InitializeObjects();

            // Serialize objects.
            using (var fs = new FileStream("objects.data", FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(fs, employee1);
                formatter.Serialize(fs, employee2);
                formatter.Serialize(fs, department);
            }

            // Deserialize objects.
            using (var fs = new FileStream("objects.data", FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                var someEmployee1 = (Employee)formatter.Deserialize(fs);
                var someEmployee2 = (Employee)formatter.Deserialize(fs);
                var someDepartment = (Department)formatter.Deserialize(fs);

                Console.WriteLine($"Binary deserialized objects:");
                Console.WriteLine($"\nEmployee1: name - {someEmployee1.EmployeeName}");
                Console.WriteLine($"\nEmployee2: name - {someEmployee2.EmployeeName}");
                Console.WriteLine($"\nDepartment: name - {someDepartment.DepartmentName}");
                Console.WriteLine($"Department: employees - {someDepartment.Employees[0].EmployeeName}, {someDepartment.Employees[1].EmployeeName}");
            }
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
