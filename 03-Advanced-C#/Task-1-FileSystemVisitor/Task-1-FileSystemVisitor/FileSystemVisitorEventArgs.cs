using System;

namespace Task_1_FileSystemVisitor
{
    /// <summary>
    /// Class with arguments used in event handlers of <see cref="FileSystemVisitor"/>.
    /// </summary>
    class FileSystemVisitorEventArgs : EventArgs
    {
        public readonly string FileItemName;
        public bool AbortSearch;

        public FileSystemVisitorEventArgs(string fileName, bool abortSearch = false, bool excludeItem = false)
        {
            FileItemName = fileName;
            AbortSearch = abortSearch;
        }
    }
}
