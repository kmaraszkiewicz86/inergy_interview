using System;
using FactoryProductSaver.Enums;

namespace FactoryProductSaver.Models
{
    public class OrderModel<TModel>
        where TModel : class
    {
        public OrderType OrderType { get; private set; }
        public Func<TModel, object> KeySelector { get; private set; }

        public OrderModel(OrderType orderType, Func<TModel, object> keySelector)
        {
            OrderType = orderType;
            KeySelector = keySelector;
        }
    }
}
