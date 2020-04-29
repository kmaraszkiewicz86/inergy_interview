using System.Collections.Generic;
using FactoryProductSaver.Models;

namespace FactoryProductSaver.Core.Interfaces
{
    public class WarehouseDataFacade
    {
        private readonly IReader _reader;
        private readonly IParser _parser;
        private readonly IWriter _writer;

        public WarehouseDataFacade(IReader reader, IParser parser, IWriter writer)
        {
            _reader = reader;
            _parser = parser;
            _writer = writer;
        }

        public IWriter ReadAndParseInput()
        {
            foreach (var line in _reader.ReadAllText())
            {
                _parser.ParseText(line);
            }

            _writer.Warehouses = _parser.ConvertedItems;
            return _writer;
        }
    }
}
