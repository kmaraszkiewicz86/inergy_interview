using System.Collections.Generic;
using System.Linq;
using WarehouseMaterialsSaver.Core.Implementations;
using WarehouseMaterialsSaver.Enums;
using WarehouseMaterialsSaver.Models;
using Xunit;
using FluentAssertions;

namespace WarehouseMaterialsSaver.Tests.Core.Implementations
{
    public class MaterialOrderByTests
    {
        private List<Material> ExpectedMaterials
        {
            get
            {
                return new List<Material>()
                {
                    new Material
                    {
                        Id = "1",
                        Name = "testA",
                        Count = 1,
                    },
                    new Material
                    {
                        Id = "2",
                        Name = "testB",
                        Count = 4,
                    },
                    new Material
                    {
                        Id = "3",
                        Name = "testC",
                        Count = 4,
                    },
                    new Material
                    {
                        Id = "4",
                        Name = "testD",
                        Count = 3,
                    },
                };
            }
        }

        [Fact]
        public void MaterialOrderBy_InputIsMaterialObjects_ReturnOrderedObjects()
        {
            

            var materialOrderBy = new MaterialOrderBy(new OrderModel<Material>[]
            {
                new OrderModel<Material>(OrderType.Asc, m => m.Count),
                new OrderModel<Material>(OrderType.Desc, m => m.Id)
            });

            var orderedItems = materialOrderBy.Execute(ExpectedMaterials);

            orderedItems.Should().BeEquivalentTo(
                ExpectedMaterials.OrderBy(i => i.Count)
                    .ThenByDescending(i => i.Name));
        }
    }
}
