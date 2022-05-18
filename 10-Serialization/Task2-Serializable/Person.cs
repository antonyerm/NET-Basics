using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Task2_Serializable
{
    [Serializable]
    public class Person : ISerializable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        protected Person(SerializationInfo info, StreamingContext context)
        {
            Name = info.GetString("name_prop");
            Age = info.GetInt32("age_prop");
        }

        public Person()
        {
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("name_prop", Name, typeof(string));
            info.AddValue("age_prop", Age, typeof(int));
        }
    }
}
