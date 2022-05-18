using System;
using System.Collections.Generic;
using System.Text;

namespace Task3_DeepCloning
{
    [Serializable]
    public class Department
    {
        public string DepartmentName;

        public List<Employee> Employees;
    }
}
