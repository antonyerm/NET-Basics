using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_FileSystemVisitor
{
    class Traverser
    {
        private readonly string startingFolder = @"C:\1";

        public void StartProgram()
        {
            var output = new OutputGenerator();
            Func<string, bool> filter1 = str => str[0] == 'a';
            Func<string, bool> filter2 = str => str[0] == 'b';
            Func<string, bool> filter3 = str => str[0] >= 'c';
            var predicates = new List<Func<string, bool>>() { filter1, filter2, filter3};

            var filesTraverser = new FileSystemVisitor(startingFolder);
            output.WriteHeader($"Unfiltered contents of {startingFolder}", false);
            foreach (var fileItem in filesTraverser.GetFilesAndFolders())
            {
                output.WriteFileItem(fileItem);
            }

            foreach (var predicate in predicates)
            {
                var filesTraverserWithFilter = new FileSystemVisitor(startingFolder, predicate);
                output.WriteHeader($"Contents of {startingFolder} filtered with filter{predicates.IndexOf(predicate) + 1}", true);
                foreach (var fileItem in filesTraverserWithFilter.GetFilesAndFolders())
                {
                    output.WriteFileItem(fileItem);
                }
            }
            
        }
    }
}
