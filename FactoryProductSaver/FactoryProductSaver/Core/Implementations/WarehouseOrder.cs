using FactoryProductSaver.Core.Interfaces;
using FactoryProductSaver.Models;

namespace FactoryProductSaver.Core.Implementations
{
    public class WarehouseOrder : OrderBase<Warehouse>
    {
        public WarehouseOrder(OrderModel<Warehouse>[] orderModels) 
            : base(orderModels)
        {
        }
    }
}
