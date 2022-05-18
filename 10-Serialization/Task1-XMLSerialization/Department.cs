using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Task1_XMLSerialization
{
    [Serializable]
    public class Department
    {
        [XmlElement]
        public string DepartmentName;
        [XmlElement]
        public List<Employee> Employees;
    }
}
