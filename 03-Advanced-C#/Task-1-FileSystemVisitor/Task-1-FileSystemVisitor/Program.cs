using System;

namespace Task_1_FileSystemVisitor
{
    /// <summary>
    /// Entry point of the application.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var traverser = new Lister();
            traverser.StartProgram();
        }
    }
}
