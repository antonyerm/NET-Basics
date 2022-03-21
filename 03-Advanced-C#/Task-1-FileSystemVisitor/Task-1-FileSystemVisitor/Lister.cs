using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_FileSystemVisitor
{
    /// <summary>
    /// Class for traversing folders and files starting with <see cref="startingFolder"/>.
    /// Uses predicates to filter the files (but not folders):
    /// filter1 - search for files starting with "a" character;
    /// filter2 - search for files starting with "b" character;
    /// filter3 - search for files starting with "c" and following in alphabet characters.
    /// 
    /// Output includes list of found files with a comment whether a file satisfies the filter or not.
    /// </summary>
    class Lister
    {
        private OutputGenerator _output;
        private readonly string startingFolder = @"C:\1";

        /// <summary>
        /// Start of the business logic.
        /// </summary>
        public void StartProgram()
        {
            _output = new OutputGenerator();
            Func<string, bool> filter1 = str => str[0] == 'a';
            Func<string, bool> filter2 = str => str[0] == 'b';
            Func<string, bool> filter3 = str => str[0] >= 'c';
            var predicates = new List<Func<string, bool>>() { filter1, filter2, filter3};

            // Unfiltered search.
            var filesVisitor = new FileSystemVisitor(startingFolder);
            InitializeVisitor(filesVisitor);
            _output.WriteHeader($"Unfiltered contents of {startingFolder}", false);
            foreach (var fileItem in filesVisitor.GetFilesAndFolders())
            {
                _output.WriteFileItem(fileItem);
            }

            // Search with different filters.
            foreach (var predicate in predicates)
            {
                var filesVisitorWithFilter = new FileSystemVisitor(startingFolder, predicate);
                InitializeVisitor(filesVisitorWithFilter);
                _output.WriteHeader($"Contents of {startingFolder} filtered with filter{predicates.IndexOf(predicate) + 1}", true);
                foreach (var fileItem in filesVisitorWithFilter.GetFilesAndFolders())
                {
                    _output.WriteFileItem(fileItem);
                }
            }
        }

        #region Events
        /// <summary>
        /// Registers methods for event handlers.
        /// </summary>
        /// <param name="visitor"></param>
        private void InitializeVisitor(FileSystemVisitor visitor)
        {
            visitor.SearchStarted += FileSystemVisitor_SearchStarted;
            visitor.SearchEnded += FileSystemVisitor_SearchEnded;
            visitor.FileFound += FileSystemVisitor_FileFound;
            visitor.DirectoryFound += FileSystemVisitor_DirectoryFound;
            visitor.FilteredFileFound += FileSystemVisitor_FilteredFileFound;
            visitor.FilteredDirectoryFound += FileSystemVisitor_FilteredDirectoryFound;
        }

        private void FileSystemVisitor_SearchStarted(object source, EventArgs e)
        {
            _output.WriteEventMessage($"Search started.");
        }

        private void FileSystemVisitor_SearchEnded(object source, EventArgs e)
        {
            _output.WriteEventMessage($"Search ended.");
        }

        private void FileSystemVisitor_FileFound(object source, FileSystemVisitorEventArgs e)
        {
            _output.WriteEventMessage($"Found unfiltered file {e.FileItemName}");
        }

        private void FileSystemVisitor_DirectoryFound(object source, FileSystemVisitorEventArgs e)
        {
            _output.WriteEventMessage($"Found unfiltered directory {e.FileItemName}");
        }

        private void FileSystemVisitor_FilteredFileFound(object source, FileSystemVisitorEventArgs e)
        {
            _output.WriteEventMessage($"Found filtered file {e.FileItemName}");
            e.AbortSearch = true;
        }

        private void FileSystemVisitor_FilteredDirectoryFound(object source, FileSystemVisitorEventArgs e)
        {
            _output.WriteEventMessage($"Found filtered directory (they are always filtered) {e.FileItemName}");
        }

        #endregion
    }
}
