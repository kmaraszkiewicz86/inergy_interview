namespace FactoryProductSaver.Core.Interfaces
{
    public interface IWarehouseDataFacade
    {
        /// <summary>
        /// First step for reading string from input
        /// </summary>
        /// <returns><see cref="IItemsFormatter"/></returns>
        IItemsFormatter ReadAndParseInput();
    }
}
