using System.Collections.Generic;
using FluentAssertions;
using Moq;
using WarehouseMaterialsSaver.Core.Interfaces;
using WarehouseMaterialsSaver.Models;
using WarehouseMaterialsSaver.Tests.Helpers;
using Xunit;

namespace WarehouseMaterialsSaver.Tests.Core.Implementations
{
    public class WarehouseDataFacadeTest
    {
        private readonly Mock<IReader> _readerMock;

        private readonly Mock<IParser> _parserMock;

        private readonly Mock<IItemsFormatter> _writerMock;

        private readonly WarehouseDataFacade _warehouseDataFacade;

        public WarehouseDataFacadeTest()
        {
            _readerMock = new Mock<IReader>();
            _parserMock = new Mock<IParser>();
            _writerMock = new Mock<IItemsFormatter>();

            var warehouseAbstractFactoryMock = new Mock<IWarehouseAbstractFactory>();

            warehouseAbstractFactoryMock.Setup(x => x.CreateReader())
                .Returns(_readerMock.Object);
            warehouseAbstractFactoryMock.Setup(x => x.CreateParser())
                .Returns(_parserMock.Object);
            warehouseAbstractFactoryMock.Setup(x => x.CreateWriter())
                .Returns(_writerMock.Object);

            _warehouseDataFacade = new WarehouseDataFacade(warehouseAbstractFactoryMock.Object);
        }

        [Fact]
        public void WarehouseDataFacade_ReturnsEmptyString()
        {
            _readerMock.Setup(x => x.ReadAllText())
                .Returns(new List<string>());
            _parserMock.Setup(x => x.ParseText(It.IsAny<string>()));
            _parserMock.Setup(x => x.ConvertedItems)
                .Returns(new List<Warehouse>());

            _writerMock.Setup(x => x.GetAllObjects())
                .Returns(new List<string>());

            _warehouseDataFacade.ReadAndParseInput().GetAllObjects().Should().BeEmpty();
        }

        [Fact]
        public void WarehouseDataFacade_ReturnsFormattedString()
        {
            _readerMock.Setup(x => x.ReadAllText())
                .Returns(new List<string>
                {
                    "#New materials",
                    "",
                    "",
                    "Cherry Hardwood Arched Door - PS;COM-100001;WH-A,5|WH-B,10",
                    "Maple Dovetail Drawerbox;COM-124047; WH-A,15",
                    "Generic Wire Pull;COM-123906c;WH-A,10|WH-B,6|WH-C,2",
                });

            _parserMock.Setup(x => x.ParseText(It.IsAny<string>()));

            _parserMock.Setup(x => x.ConvertedItems)
                .Returns(WarehouseModelExpectedDataHelper.ExpectedWarehouseModels);

            _writerMock.Setup(x => x.GetAllObjects())
                .Returns(WarehouseModelExpectedDataHelper.ExpectedWarehouseModelsInFormattedStringLines);

            _warehouseDataFacade.ReadAndParseInput().GetAllObjects().Should().BeEquivalentTo(
                WarehouseModelExpectedDataHelper.ExpectedWarehouseModelsInFormattedStringLines);

            _parserMock.Verify(x => x.ParseText(It.IsAny<string>()),
                Times.Exactly(6));
        }
    }
}