using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Task1_XMLSerialization
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
            // Employee1
            var serializerForEmployee = new XmlSerializer(typeof(Employee));
            using (var fs = new FileStream("Employee1Data.xml", FileMode.Create))
            {
                serializerForEmployee.Serialize(fs, employee1);
            }

            // Employee2
            using (var fs = new FileStream("Employee2Data.xml", FileMode.Create))
            {
                serializerForEmployee.Serialize(fs, employee2);
            }

            // Department
            var serializerForDepartment = new XmlSerializer(typeof(Department));
            using (var fs = new FileStream("DepartmentData.xml", FileMode.Create))
            {
                serializerForDepartment.Serialize(fs, department);
            }

            // Deserialize objects.
            Employee someEmployee1;
            Employee someEmployee2;
            Department someDepartment;
            using (var fs = new FileStream("Employee1Data.xml", FileMode.Open))
            {
                someEmployee1 = (Employee)serializerForEmployee.Deserialize(fs);
            }

            using (var fs = new FileStream("Employee2Data.xml", FileMode.Open))
            {
                someEmployee2 = (Employee)serializerForEmployee.Deserialize(fs);
            }

            using (var fs = new FileStream("DepartmentData.xml", FileMode.Open))
            {
                someDepartment = (Department)serializerForDepartment.Deserialize(fs);
            }

            Console.WriteLine($"XML deserialized objects:");
            Console.WriteLine($"\nEmployee1: name - {someEmployee1.EmployeeName}");
            Console.WriteLine($"\nEmployee2: name - {someEmployee2.EmployeeName}");
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
