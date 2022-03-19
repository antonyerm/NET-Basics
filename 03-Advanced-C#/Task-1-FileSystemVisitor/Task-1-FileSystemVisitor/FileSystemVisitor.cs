using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task_1_FileSystemVisitor
{
    class FileSystemVisitor
    {
        private string _startingFolder;
        private Func<string, bool> filter;

        public FileSystemVisitor(string startingFolder)
        {
            _startingFolder = startingFolder;
        }

        public FileSystemVisitor(string startingFolder, Func<string, bool> predicate) : this(startingFolder)
        {
            filter = predicate;
        }

        public IEnumerable<string> GetFilesAndFolders()
        {
            var directoryInfo = new DirectoryInfo(_startingFolder);
            foreach (var fileInfo in directoryInfo.GetFiles("*", SearchOption.AllDirectories))
            {
                if (filter != null && filter(fileInfo.Name))
                {
                    yield return fileInfo.Name;
                }
            }
        }
    }
}
