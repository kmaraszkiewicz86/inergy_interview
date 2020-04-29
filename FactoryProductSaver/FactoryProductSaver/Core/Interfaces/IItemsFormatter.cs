using System.Collections.Generic;
using FactoryProductSaver.Models;

namespace FactoryProductSaver.Core.Interfaces
{
    public interface IItemsFormatter
    {
        /// <summary>
        /// <see cref="Warehouse"/> object converted from input strings
        /// </summary>
        IEnumerable<Warehouse> Warehouses { get; set; }

        /// <summary>
        /// Get all converted and formatted items
        /// </summary>
        /// <returns>Formatted items</returns>
        IEnumerable<string> GetAllObjects();
    }
}
