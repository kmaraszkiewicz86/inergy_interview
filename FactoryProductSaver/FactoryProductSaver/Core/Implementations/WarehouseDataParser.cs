using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FactoryProductSaver.Core.Interfaces;
using FactoryProductSaver.Models;

namespace FactoryProductSaver.Core.Implementations
{
    /// <summary>
    /// Functionality for parse input string
    /// </summary>
    public class WarehouseDataParser : IParser
    {
        /// <summary>
        /// Items that was matched with success by regex format
        /// </summary>
        public IEnumerable<Warehouse> ConvertedItems => _convertedItems;

        /// <summary>
        /// Format to check match with fetched line of data
        /// </summary>
        private readonly Regex _formatRegex = new Regex(@"^(?!.*#)(.+);(.+);(.+)|{3,*}((.+),(\d+))$");

        /// <summary>
        /// <see cref="ConvertedItems"/>
        /// </summary>
        private readonly List<Warehouse> _convertedItems = new List<Warehouse>();

        /// <summary>
        /// Parse line of fetched string
        /// </summary>
        /// <param name="line"></param>
        public void ParseText(string line)
        {
            var result = _formatRegex.Match(line);

            if (result.Success)
            {
                var matchedGroups = result.Groups.Values.ToArray();

                foreach (string value in matchedGroups[3].Value.Split('|'))
                {
                    AddMaterialsToWarehouse(matchedGroups, value);
                }
            }
        }

        /// <summary>
        /// Match format string into warehouse object
        /// </summary>
        /// <param name="matchedGroups"></param>
        /// <param name="value"></param>
        private void AddMaterialsToWarehouse(IReadOnlyList<Group> matchedGroups, string value)
        {
            var warehouseData = value.Split(',');
            var warehouse =
                _convertedItems.FirstOrDefault(w =>
                    String.Equals(w.Name, warehouseData[0], StringComparison.CurrentCultureIgnoreCase));

            if (warehouse == null)
            {
                warehouse = new Warehouse
                {
                    Materials = new List<Material>(),
                    Name = warehouseData[0]
                };

                _convertedItems.Add(warehouse);
            }

            warehouse.Materials.Add(new Material
            {
                Id = matchedGroups[2].Value,
                Name = matchedGroups[1].Value,
                Count = Convert.ToInt32(warehouseData[1])
            });
        }
    }
}