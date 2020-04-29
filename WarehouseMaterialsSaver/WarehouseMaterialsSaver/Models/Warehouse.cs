using System.Collections.Generic;
using System.Linq;

namespace WarehouseMaterialsSaver.Models
{
    /// <summary>
    /// Abstract object representing Warehouse model
    /// </summary>
    public class Warehouse
    {
        /// <summary>
        /// The name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Materials reference to this object
        /// </summary>
        public IList<Material> Materials { get; set; } = new List<Material>();

        /// <summary>
        /// Count of added <see cref="Materials"/>
        /// </summary>
        public int CountOfMaterials =>
            Materials.Select(m => m.Count).Sum();
    }
}
