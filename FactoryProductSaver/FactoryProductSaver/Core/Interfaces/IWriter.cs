using System.Collections.Generic;
using FactoryProductSaver.Models;

namespace FactoryProductSaver.Core.Interfaces
{
    public interface IWriter
    {
        IEnumerable<Warehouse> Warehouses { get; set; }

        IEnumerable<string> GetAllObjects();
    }
}
