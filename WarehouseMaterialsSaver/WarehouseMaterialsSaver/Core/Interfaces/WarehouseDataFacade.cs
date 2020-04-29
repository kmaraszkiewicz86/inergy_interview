using WarehouseMaterialsSaver.Core.Implementations;

namespace WarehouseMaterialsSaver.Core.Interfaces
{
    public class WarehouseDataFacade: IWarehouseDataFacade
    {
        /// <summary>
        /// <see cref="IReader"/>
        /// </summary>
        private readonly IReader _reader;

        /// <summary>
        /// <see cref="IParser"/>
        /// </summary>
        private readonly IParser _parser;

        /// <summary>
        /// <see cref="IItemsFormatter"/>
        /// </summary>
        private readonly IItemsFormatter _itemsFormatter;

        /// <summary>
        /// Create instance of class
        /// </summary>
        /// <param name="warehouseAbstractFactory"><see cref="WarehouseAbstractFactory"/></param>
        public WarehouseDataFacade(WarehouseAbstractFactory warehouseAbstractFactory)
        {
            _reader = warehouseAbstractFactory.CreateReader();
            _parser = warehouseAbstractFactory.CreateParser();
            _itemsFormatter = warehouseAbstractFactory.CreateWriter();
        }

        /// <summary>
        /// First step for reading string from input
        /// </summary>
        /// <returns><see cref="IItemsFormatter"/></returns>
        public IItemsFormatter ReadAndParseInput()
        {
            foreach (var line in _reader.ReadAllText())
            {
                _parser.ParseText(line);
            }

            _itemsFormatter.Warehouses = _parser.ConvertedItems;
            return _itemsFormatter;
        }
    }
}
