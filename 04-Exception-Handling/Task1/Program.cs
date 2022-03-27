using System;

namespace Task1
{
    internal class Program
    {
        const string ExitKeyword = "exit";
        private static void Main(string[] args)
        {
            string input = default(string);

            do
            {
                Console.WriteLine("Please enter a string. Enter \"exit\" to finish.");

                try
                {
                    input = Console.ReadLine();
                    var output = string.IsNullOrEmpty(input) ? throw new ArgumentException("The string must have some characters in it!")
                        : input[0];
                    if (input != ExitKeyword)
                    {
                        Console.WriteLine($"The first character of your string is {output}");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (input != ExitKeyword);

            Console.WriteLine("Goodbye.");
        }
    }
}