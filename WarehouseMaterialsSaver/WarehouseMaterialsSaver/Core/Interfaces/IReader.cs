using System.Collections.Generic;

namespace WarehouseMaterialsSaver.Core.Interfaces
{
    public interface IReader
    {
        /// <summary>
        /// Reads all text typed on std in
        /// </summary>
        IEnumerable<string> ReadAllText();
    }
}
