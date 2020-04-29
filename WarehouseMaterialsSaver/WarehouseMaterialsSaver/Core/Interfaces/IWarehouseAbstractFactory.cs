namespace WarehouseMaterialsSaver.Core.Interfaces
{
    /// <summary>
    /// Helper class to match referenced object
    /// </summary>
    public interface IWarehouseAbstractFactory
    {
        /// <summary>
        /// Create reader
        /// </summary>
        /// <returns><see cref="IReader"/></returns>
        IReader CreateReader();

        /// <summary>
        /// Create parser
        /// </summary>
        /// <returns><see cref="IParser"/></returns>
        IParser CreateParser();

        /// <summary>
        /// Create writer
        /// </summary>
        /// <returns><see cref="IItemsFormatter"/></returns>
        IItemsFormatter CreateWriter();
    }
}
