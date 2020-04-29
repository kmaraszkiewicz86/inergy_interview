using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using FactoryProductSaver.Core.Interfaces;
using FactoryProductSaver.Models;

namespace FactoryProductSaver.Core.Implementations
{
    public class WarehouseDataParser : IParser
    {
        private Regex regex => new Regex(@"^(?!.*#)(.+);(.+);(.+)|{3,*}((.+),(\d+))$");

        private List<Warehouse> _convertedItems = new List<Warehouse>();

        public IEnumerable<Warehouse> ConvertedItems => _convertedItems;

        public string InCompletedLine { get; set; }

        public void ParseText(string line)
        {
            var result = MatchString(line);

            if (result.Success)
            {
                var values = result.Groups.Values.ToArray();

                var material = new Material()
                {
                    Id = values[2].Value,
                    Name = values[1].Value
                };

                foreach (var value in values[3].Value.Split('|'))
                {
                    var warehouseData = value.Split(',');
                    var warehouse =
                        _convertedItems.FirstOrDefault(w => w.Name.ToLower() == warehouseData[0].ToLower());

                    if (warehouse == null)
                    {
                        warehouse = new Warehouse
                        {
                            Materials = new List<Material>(),
                            Name = warehouseData[0]
                        };

                        _convertedItems.Add(warehouse);
                    }

                    material.Count = Convert.ToInt32(warehouseData[1]);

                    warehouse.Materials.Add(material);
                }
            }
        }

        private Match MatchString(string line)
        {
            return regex.Match(line);
        }
    }
}