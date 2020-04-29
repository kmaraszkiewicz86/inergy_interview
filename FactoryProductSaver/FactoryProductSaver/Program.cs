using System;
using FactoryProductSaver.Core.Implementations;
using FactoryProductSaver.Core.Interfaces;
using FactoryProductSaver.Enums;
using FactoryProductSaver.Models;

namespace FactoryProductSaver
{
    class Program
    {
        static void Main(string[] args)
        {
            //todo: add builder and factory method or abstract factory
            IReader reader = new StdInReader();
            IParser parser = new WarehouseDataParser();

            //todo: move to abstract or builder class
            IOrder<Warehouse> warehouseOrder = new WarehouseOrder(new []
            {
                new OrderModel<Warehouse>(OrderType.Desc, w => w.CountOfMaterials),
                new OrderModel<Warehouse>(OrderType.Desc, w => w.Name)
            });

            IOrder<Material> materialOrder = new MaterialOrder(new[]
            {
                new OrderModel<Material>(OrderType.Asc, w => w.Id),
            });

            IWriter writer = new StdOutWriter(warehouseOrder, materialOrder);

            var warehouseDataFacade = new WarehouseDataFacade(reader, parser, writer);

            foreach (var item in warehouseDataFacade.ReadAndParseInput().GetAllObjects())
            {
                Console.WriteLine();
                Console.WriteLine(item);
                Console.WriteLine();
            }
        }
    }
}

