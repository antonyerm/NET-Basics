using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task2_Serializable
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "person.data";

            IFormatter formatter = new BinaryFormatter();
            SerializeItem(fileName, formatter); 
            DeserializeItem(fileName, formatter); 
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static void SerializeItem(string fileName, IFormatter formatter)
        {
            var person = new Person();
            person.Name = "John Mayer";
            person.Age = 42;

            FileStream s = new FileStream(fileName, FileMode.Create);
            formatter.Serialize(s, person);
            s.Close();
        }

        private static void DeserializeItem(string fileName, IFormatter formatter)
        {
            FileStream s = new FileStream(fileName, FileMode.Open);
            var person = (Person)formatter.Deserialize(s);
            Console.WriteLine($"Name: {person.Name}\nAge: {person.Age}");
        }
    }
}
