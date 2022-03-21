using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task_1_FileSystemVisitor
{
    /// <summary>
    /// Class with file search methods.
    /// </summary>
    class FileSystemVisitor
    {
        private string _startingFolder;
        private Func<string, bool> filter;
        private bool _abortSearch;
        public event EventHandler SearchStarted;
        public event EventHandler SearchEnded;
        public event EventHandler<FileSystemVisitorEventArgs> FileFound;
        public event EventHandler<FileSystemVisitorEventArgs> DirectoryFound;
        public event EventHandler<FileSystemVisitorEventArgs> FilteredFileFound;
        public event EventHandler<FileSystemVisitorEventArgs> FilteredDirectoryFound;

        #region Events

        protected virtual void OnSearchStarted(EventArgs e)
        {
            SearchStarted?.Invoke(this, e);
        }

        protected virtual void OnSearchEnded(EventArgs e)
        {
            SearchEnded?.Invoke(this, e);
        }

        protected virtual void OnFileFound(FileSystemVisitorEventArgs e)
        {
            FileFound?.Invoke(this, e);
        }

        protected virtual void OnDirectoryFound(FileSystemVisitorEventArgs e)
        {
            DirectoryFound?.Invoke(this, e);
        }

        protected virtual void OnFilteredFileFound(FileSystemVisitorEventArgs e)
        {
            FilteredFileFound?.Invoke(this, e);
        }

        protected virtual void OnFilteredDirectoryFound(FileSystemVisitorEventArgs e)
        {
            FilteredDirectoryFound?.Invoke(this, e);
        }

        #endregion

        public FileSystemVisitor(string startingFolder)
        {
            _startingFolder = startingFolder;
        }

        public FileSystemVisitor(string startingFolder, Func<string, bool> predicate) : this(startingFolder)
        {
            filter = predicate;
        }

        /// <summary>
        /// Entry point of search.
        /// Initializes search and calls overloaded recursion method.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetFilesAndFolders()
        {
            _abortSearch = false;
            OnSearchStarted(EventArgs.Empty);
            return GetFilesAndFolders(_startingFolder);
        }

        /// <summary>
        /// Recursive search method which gets into every folder it finds.
        /// </summary>
        /// <param name="parentDirectory"></param>
        /// <returns></returns>
        public IEnumerable<string> GetFilesAndFolders(string parentDirectory)
        {
            // Searches for files in current folder.
            foreach (var fullFileName in Directory.GetFiles(parentDirectory))
            {
                var fileName = Path.GetFileName(fullFileName);
                OnFileFound(new FileSystemVisitorEventArgs(fileName));
                if (filter == null || (filter != null && filter(fileName)))
                {
                    if (filter != null)
                    {
                        var args = new FileSystemVisitorEventArgs(fileName);
                        OnFilteredFileFound(args);
                        // Handles response from event handler.
                        if (args.AbortSearch)
                        {
                            _abortSearch = true;
                        }
                    }
                    
                    yield return fileName;

                    if (_abortSearch)
                    {
                        break;
                    }
                }
            }

            // Searches for folders in current folder.
            foreach (var directoryName in Directory.GetDirectories(parentDirectory))
            {
                if (_abortSearch)
                {
                    break;
                }
                OnDirectoryFound(new FileSystemVisitorEventArgs(directoryName));
                OnFilteredDirectoryFound(new FileSystemVisitorEventArgs(directoryName));
                yield return directoryName;
                foreach (var fileItem in GetFilesAndFolders(directoryName))
                {
                    yield return fileItem;
                }
            }

            // Checks if we are at the top of recursion and the method is about to finish.
            if (parentDirectory == _startingFolder)
            {
                OnSearchEnded(EventArgs.Empty);
            }
        }
    }
}
