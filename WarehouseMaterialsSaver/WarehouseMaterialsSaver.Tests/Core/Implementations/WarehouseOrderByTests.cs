using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using WarehouseMaterialsSaver.Core.Implementations;
using WarehouseMaterialsSaver.Enums;
using WarehouseMaterialsSaver.Models;
using Xunit;

namespace WarehouseMaterialsSaver.Tests.Core.Implementations
{
    public class WarehouseOrderByTests
    {
        private List<Warehouse> ExpectedItems
        {
            get
            {
                return new List<Warehouse>
                {
                    new Warehouse()
                    {
                        Name = "TestA",
                        Materials = new List<Material>
                        {
                            new Material
                            {
                                Id = "1",
                                Name = "TestA.A",
                                Count = 10
                            },
                            new Material
                            {
                                Id = "2",
                                Name = "TestA.B",
                                Count = 1
                            },
                            new Material
                            {
                                Id = "3",
                                Name = "TestA.C",
                                Count = 3
                            }
                        }
                    },
                    new Warehouse
                    {
                        Name = "TestB",
                        Materials = new List<Material>
                        {
                            new Material
                            {
                                Id = "3",
                                Name = "TestB.A",
                                Count = 1
                            },
                            new Material
                            {
                                Id = "4",
                                Name = "TestB.B",
                                Count = 2
                            }
                        }
                    },
                    new Warehouse
                    {
                        Name = "TestC",
                        Materials = new List<Material>
                        {
                            new Material
                            {
                                Id = "5",
                                Name = "TestC.A",
                                Count = 2
                            },
                            new Material
                            {
                                Id = "6",
                                Name = "TestC.B",
                                Count = 1
                            }
                        }
                    },
                };
            }
        }

        [Fact]
        public void MaterialOrderBy_InputIsMaterialObjects_ReturnOrderedObjects()
        {
            var materialOrderBy = new WarehouseOrderBy(new []
            {
                new OrderModel<Warehouse>(OrderType.Desc, w => w.CountOfMaterials),
                new OrderModel<Warehouse>(OrderType.Desc, w => w.Name)
            });

            var orderedItems = materialOrderBy.Execute(ExpectedItems);

            orderedItems.Should().BeEquivalentTo(
                ExpectedItems.OrderByDescending(i => i.CountOfMaterials)
                    .ThenByDescending(i => i.Name));
        }
    }
}
