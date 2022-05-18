using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySerialization
{
    [Serializable]
    public class Department
    {
        public string DepartmentName;

        public List<Employee> Employees;
    }
}
