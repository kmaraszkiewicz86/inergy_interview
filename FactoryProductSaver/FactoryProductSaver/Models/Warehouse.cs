using System.Collections.Generic;
using System.Linq;

namespace FactoryProductSaver.Models
{
    public class Warehouse
    {
        public string Name { get; set; }

        public IList<Material> Materials { get; set; } = new List<Material>();

        public int CountOfMaterials =>
            Materials.Select(m => m.Count).Sum();
    }
}
