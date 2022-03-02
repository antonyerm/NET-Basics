using System;
using Task2_Class_library;

namespace Task1_1_Console_app
{
    class Program
    {
        static void Main(string[] args)
        {
            var userName = args.Length > 0 ? args[0] : "Mr.UnKnown";
            Console.WriteLine($"Hello, {userName}!");
            var resultFromClassLibrary = TextProcessing.CreateGreeting(userName);
            Console.WriteLine($"Result from the class library: {resultFromClassLibrary}");
        }
    }
}
