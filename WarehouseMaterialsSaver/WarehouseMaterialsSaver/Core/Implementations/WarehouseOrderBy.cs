using WarehouseMaterialsSaver.Core.Interfaces;
using WarehouseMaterialsSaver.Models;

namespace WarehouseMaterialsSaver.Core.Implementations
{

    /// <summary>
    /// Class for ordering <see cref="Warehouse"/> objects
    /// </summary>
    public class WarehouseOrderBy : OrderByBase<Warehouse>
    {
        /// <summary>
        /// Initialize class
        /// </summary>
        /// <param name="orderModels">Steps for ordering steps to execute by class</param>
        public WarehouseOrderBy(OrderModel<Warehouse>[] orderModels) 
            : base(orderModels)
        {
        }
    }
}
