using System.Collections.Generic;
using System.Linq;

namespace WarehouseMaterialsSaver.Core.Interfaces
{
    /// <summary>
    /// Helper class to match referenced object
    /// </summary>
    public interface IOrderBy<TModel>
        where TModel : class
    {
        /// <summary>
        /// Execute n orders step depend on OrderModels definition
        /// </summary>
        /// <param name="items">Items for sorting</param>
        /// <returns><see cref="IOrderedEnumerable{TModel}"/></returns>
        IOrderedEnumerable<TModel> Execute(IEnumerable<TModel> items);
    }
}
