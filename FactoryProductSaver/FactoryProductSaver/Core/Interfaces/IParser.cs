using System;
using System.Collections.Generic;
using System.Text;
using FactoryProductSaver.Models;

namespace FactoryProductSaver.Core.Interfaces
{
    public interface IParser
    {
        IEnumerable<Warehouse> ConvertedItems { get; }

        void ParseText(string line);
    }
}
