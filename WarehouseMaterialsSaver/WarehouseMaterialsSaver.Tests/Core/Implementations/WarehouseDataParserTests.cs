using System.Collections.Generic;
using FluentAssertions;
using WarehouseMaterialsSaver.Core.Implementations;
using WarehouseMaterialsSaver.Tests.Helpers;
using Xunit;

namespace WarehouseMaterialsSaver.Tests.Core.Implementations
{
    public class WarehouseDataParserTests
    {
        private readonly WarehouseDataParser _warehouseDataParser;

        public WarehouseDataParserTests()
        {
            _warehouseDataParser = new WarehouseDataParser();
        }

        [Fact]
        public void WarehouseDataParser_InputIsString_ReturnParsedItems()
        {
            var lines = new List<string>
            {
                "#Material inventory initial state as of Jan 01 2018",
                "#New materials",
                "",
                "",
                "Cherry Hardwood Arched Door - PS;COM-100001;WH-A,5|WH-B,10",
                "Maple Dovetail Drawerbox;COM-124047;WH-A,15",
                "Generic Wire Pull;COM-123906c;WH-A,10|WH-B,6|WH-C,2",
                "Yankee Hardware 110 Deg.Hinge;COM-123908;WH-A,10|WH-B,11",
                "#Existing materials, restocked",
                "Hdw Accuride CB0115-CASSRC - Locking Handle Kit-Black;CB0115-CASSRC;WH-C,13|WHB,5",
                "Veneer - Charter Industries - 3M Adhesive Backed -Cherry 10mm - Paper Back;3MCherry-10mm;WH-A,10|WH-B,1",
                "Veneer - Cherry Rotary 1 FSC;COM-123823;WH-C,10 MDF,CARB2,11/8;COM-101734;WH-C,8",
                "Veneer - Cherry Rotary 1 FSC;COM-12",
                "Veneer - "
            };

            foreach (var line in lines)
            {
                _warehouseDataParser.ParseText(line);
            }

            _warehouseDataParser.ConvertedItems.Should().BeEquivalentTo(WarehouseModelExpectedDataHelper.ExpectedWarehouseModels);
        }

        [Fact]
        public void WarehouseDataParser_InputIsEmptyString_ReturnParsedEmptyCollection()
        {
            _warehouseDataParser.ParseText("");
            _warehouseDataParser.ParseText("");
            _warehouseDataParser.ParseText("");

            _warehouseDataParser.ConvertedItems.Should().BeEmpty();
        }
    }
}