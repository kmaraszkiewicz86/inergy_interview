using System.Collections.Generic;
using FactoryProductSaver.Models;

namespace FactoryProductSaver.Core.Interfaces
{
    /// <summary>
    /// Functionality for parse input string
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Items that was matched with success by regex format
        /// </summary>
        IEnumerable<Warehouse> ConvertedItems { get; }

        /// <summary>
        /// Parse line of fetched string
        /// </summary>
        /// <param name="line"></param>
        void ParseText(string line);
    }
}