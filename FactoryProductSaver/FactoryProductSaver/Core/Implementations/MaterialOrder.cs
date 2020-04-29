using FactoryProductSaver.Core.Interfaces;
using FactoryProductSaver.Models;

namespace FactoryProductSaver.Core.Implementations
{
    public class MaterialOrder : OrderBase<Material>
    {
        public MaterialOrder(OrderModel<Material>[] orderModels)
            : base(orderModels)
        {
        }
    }
}
