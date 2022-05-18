using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace JSONSerialization
{
    public class Department
    {
        [JsonInclude]
        public string DepartmentName;

        [JsonInclude]
        public List<Employee> Employees;
    }
}
