using FactoryProductSaver.Core.Interfaces;
using FactoryProductSaver.Models;

namespace FactoryProductSaver.Core.Implementations
{
    /// <summary>
    /// Helper class to match referenced object
    /// </summary>
    public class WarehouseAbstractFactory: IWarehouseAbstractFactory
    {
        private readonly IOrderBy<Warehouse> _warehouseOrderBy;

        private readonly IOrderBy<Material> _materialOrderBy;

        /// <summary>
        /// Create instance of class
        /// </summary>
        /// <param name="warehouseOrderBy"><see cref="WarehouseOrderBy"/></param>
        /// <param name="materialOrderBy"><see cref="MaterialOrderBy"/></param>
        public WarehouseAbstractFactory(IOrderBy<Warehouse> warehouseOrderBy, 
            IOrderBy<Material> materialOrderBy)
        {
            _warehouseOrderBy = warehouseOrderBy;
            _materialOrderBy = materialOrderBy;

        }

        /// <summary>
        /// Create reader
        /// </summary>
        /// <returns><see cref="IReader"/></returns>
        public IReader CreateReader()
        {
            return new StdInReader();
        }

        /// <summary>
        /// Create parser
        /// </summary>
        /// <returns><see cref="IParser"/></returns>
        public IParser CreateParser()
        {
            return new WarehouseDataParser();
        }

        /// <summary>
        /// Create writer
        /// </summary>
        /// <returns><see cref="IItemsFormatter"/></returns>
        public IItemsFormatter CreateWriter()
        {
            return new WarehouseItemsFormatter(_warehouseOrderBy, _materialOrderBy);
        }
    }
}
