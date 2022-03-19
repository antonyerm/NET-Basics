using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_FileSystemVisitor
{
    class OutputGenerator
    {
        public void WriteFileItem(string fileItem)
        {
            Console.WriteLine(fileItem);
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
    }
}
