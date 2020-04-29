using FactoryProductSaver.Core.Interfaces;
using FactoryProductSaver.Models;

namespace FactoryProductSaver.Core.Implementations
{
    /// <summary>
    /// Class for ordering <see cref="Material"/> objects
    /// </summary>
    public class MaterialOrderBy : OrderByBase<Material>
    {
        /// <summary>
        /// Initialize class
        /// </summary>
        /// <param name="orderModels">Steps for ordering steps to execute by class</param>
        public MaterialOrderBy(OrderModel<Material>[] orderModels)
            : base(orderModels)
        {
        }
    }
}
