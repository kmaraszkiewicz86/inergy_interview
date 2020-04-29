using System.Collections.Generic;
using System.Linq;

namespace FactoryProductSaver.Core.Interfaces
{
    public interface IOrder<TModel>
        where TModel : class
    {
        IOrderedEnumerable<TModel> OrderBy(IEnumerable<TModel> items);
    }
}
