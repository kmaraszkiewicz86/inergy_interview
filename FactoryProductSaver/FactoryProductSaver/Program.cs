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
            IOrderBy<Warehouse> warehouseOrderBy = new WarehouseOrderBy(new[]
            {
                new OrderModel<Warehouse>(OrderType.Desc, w => w.CountOfMaterials),
                new OrderModel<Warehouse>(OrderType.Desc, w => w.Name)
            });

            IOrderBy<Material> materialOrderBy = new MaterialOrderBy(new[]
            {
                new OrderModel<Material>(OrderType.Asc, w => w.Id),
            });

            var warehouseAbstractFactory = new WarehouseAbstractFactory(warehouseOrderBy, materialOrderBy);

            var warehouseDataFacade = new WarehouseDataFacade(warehouseAbstractFactory);

            foreach (var item in warehouseDataFacade.ReadAndParseInput().GetAllObjects())
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
        }
    }
}