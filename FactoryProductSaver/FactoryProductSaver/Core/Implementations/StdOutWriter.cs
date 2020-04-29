using System.Collections.Generic;
using System.Text;
using FactoryProductSaver.Core.Interfaces;
using FactoryProductSaver.Models;

namespace FactoryProductSaver.Core.Implementations
{
    public class StdOutWriter: IWriter
    {
        public IEnumerable<Warehouse> Warehouses { get; set; }

        private readonly IOrder<Warehouse> _warehouseOrder;

        private readonly IOrder<Material> _materialOrder;

        public StdOutWriter(IOrder<Warehouse> warehouseOrder, IOrder<Material> materialOrder)
        {
            Warehouses = new List<Warehouse>();

            _warehouseOrder = warehouseOrder;
            _materialOrder = materialOrder;
            
        }

        public IEnumerable<string> GetAllObjects()
        {
            var strBuilder = new StringBuilder();

            foreach (var warehouse in _warehouseOrder.OrderBy(Warehouses))
            {
                strBuilder.Clear();

                strBuilder.AppendLine($"{warehouse.Name} ({warehouse.CountOfMaterials})");

                foreach (var material in _materialOrder.OrderBy(warehouse.Materials))
                {
                    strBuilder.AppendLine($"{material.Id}: ({material.Count})");
                }

                yield return strBuilder.ToString();
            }
        }
    }
}
