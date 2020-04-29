using System.Collections.Generic;
using System.Text;
using WarehouseMaterialsSaver.Core.Interfaces;
using WarehouseMaterialsSaver.Models;

namespace WarehouseMaterialsSaver.Core.Implementations
{
    public class WarehouseItemsFormatter: IItemsFormatter
    {
        /// <summary>
        /// <see cref="Warehouse"/> object converted from input strings
        /// </summary>
        public IEnumerable<Warehouse> Warehouses { get; set; }

        /// <summary>
        /// <see cref="IOrderBy{Warehouse}"/>
        /// </summary>
        private readonly IOrderBy<Warehouse> _warehouseOrderBy;

        /// <summary>
        /// <see cref="IOrderBy{Material}"/>
        /// </summary>
        private readonly IOrderBy<Material> _materialOrderBy;

        /// <summary>
        /// Create instance of class
        /// </summary>
        /// <param name="warehouseOrderBy"><see cref="WarehouseOrderBy"/></param>
        /// <param name="materialOrderBy"><see cref="MaterialOrderBy"/></param>
        public WarehouseItemsFormatter(IOrderBy<Warehouse> warehouseOrderBy, IOrderBy<Material> materialOrderBy)
        {
            Warehouses = new List<Warehouse>();

            _warehouseOrderBy = warehouseOrderBy;
            _materialOrderBy = materialOrderBy;
            
        }

        /// <summary>
        /// Get all converted and formatted items
        /// </summary>
        /// <returns>Formatted items</returns>
        public IEnumerable<string> GetAllObjects()
        {
            var strBuilder = new StringBuilder();

            foreach (var warehouse in _warehouseOrderBy.Execute(Warehouses))
            {
                strBuilder.Clear();

                strBuilder.AppendLine($"{warehouse.Name} ({warehouse.CountOfMaterials})");

                foreach (var material in _materialOrderBy.Execute(warehouse.Materials))
                {
                    strBuilder.AppendLine($"{material.Id}: {material.Count}");
                }

                yield return strBuilder.ToString();
            }
        }
    }
}