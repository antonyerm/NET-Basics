using FileCabinet.Interfaces;
using FileCabinet.Output;
using FileCabinet.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileCabinet
{
    class Cabinet
    {
        private IStorage _storage;
        private IOutput _output;

        public Cabinet(IStorage storage = null, IOutput output = null)
        {
            _storage = storage == null ? new FileStorage() : storage;
            _output = output == null ? new ConsoleOutput() : output;
        }

        public IDocument SearchDocumentByNumber(int number)
        {
            var document = _storage.GetDocumentByNumber(number);
            if (document is IPrintable printableDocument)
            {
                printableDocument.PrintDocumentProperties(_output);
            }

            return document;
        }
    }
}
