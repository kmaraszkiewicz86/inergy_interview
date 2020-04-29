using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Moq;
using WarehouseMaterialsSaver.Core.Implementations;
using WarehouseMaterialsSaver.Core.Interfaces;
using WarehouseMaterialsSaver.Models;
using WarehouseMaterialsSaver.Tests.Helpers;
using Xunit;

namespace WarehouseMaterialsSaver.Tests.Core.Implementations
{
    public class WarehouseItemsFormatterTests
    {
        private readonly Mock<IOrderBy<Warehouse>> _warehouseOrderBy;
        private readonly Mock<IOrderBy<Material>> _materialOrderBy;
        private readonly WarehouseItemsFormatter _warehouseItemsFormatter;

        public WarehouseItemsFormatterTests()
        {
            _warehouseOrderBy = new Mock<IOrderBy<Warehouse>>();
            _materialOrderBy = new Mock<IOrderBy<Material>>();

            _warehouseItemsFormatter = new WarehouseItemsFormatter(_warehouseOrderBy.Object,
                _materialOrderBy.Object);

        }

        [Fact]
        public void IsWarehouseItemsFormatter_InputIsEmptyCollection_ReturnEmptyItems()
        {
            _warehouseItemsFormatter.Warehouses = new List<Warehouse>();

            _warehouseOrderBy.Setup(x => x.Execute(It.IsAny<List<Warehouse>>()))
                .Returns(() => new List<Warehouse>().OrderBy(x => x.Name));

            _materialOrderBy.Setup(x => x.Execute(It.IsAny<List<Material>>()))
                .Returns(() => new List<Material>().OrderBy(x => x.Name));

            var result = _warehouseItemsFormatter.GetAllObjects();

            result.Should().BeEmpty();
        }

        [Fact]
        public void IsWarehouseItemsFormatter_InputIsCollection_ReturnNotEmptyFormattedString()
        {
            _warehouseItemsFormatter.Warehouses = new List<Warehouse>();

            _warehouseOrderBy.Setup(x => x.Execute(It.IsAny<List<Warehouse>>()))
                .Returns(() => WarehouseModelExpectedDataHelper.ExpectedWarehouseModels.Take(1).OrderBy(x => x.Name));

            _materialOrderBy.Setup(x => x.Execute(It.IsAny<List<Material>>()))
                .Returns(() => 
                    WarehouseModelExpectedDataHelper.ExpectedWarehouseModels.First().Materials.OrderBy(m => m.Name));

            var result = _warehouseItemsFormatter.GetAllObjects().ToList();

            result.Should().NotBeEmpty();

            result.Should().BeEquivalentTo(WarehouseModelExpectedDataHelper.ExpectedWarehouseModelsInFormattedStringLines);
        }
    }
}