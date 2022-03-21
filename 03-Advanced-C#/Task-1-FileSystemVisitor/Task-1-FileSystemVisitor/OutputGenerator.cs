using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_FileSystemVisitor
{
    /// <summary>
    /// Class which provides output methods for different types of messages.
    /// </summary>
    class OutputGenerator
    {
        public void WriteFileItem(string fileItem)
        {
            Console.WriteLine(fileItem.ToUpper());
        }

        public void WriteHeader(string header, bool newLine)
        {
            if (newLine)
            {
                Console.WriteLine();
            }
            Console.WriteLine(header);
            Console.WriteLine(String.Empty.PadLeft(header.Length, '='));
        }

        public void WriteEventMessage(string message)
        {
            Console.WriteLine($"Event received: {message}");
        }
    }
}
