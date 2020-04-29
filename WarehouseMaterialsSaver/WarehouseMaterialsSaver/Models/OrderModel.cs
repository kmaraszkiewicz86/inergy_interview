using System;
using WarehouseMaterialsSaver.Enums;

namespace WarehouseMaterialsSaver.Models
{
    /// <summary>
    /// Model defines orders steps to execute
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class OrderModel<TModel>
        where TModel : class
    {
        /// <summary>
        /// Order type <see cref="OrderType"/>
        /// </summary>
        public OrderType OrderType { get; private set; }

        /// <summary>
        /// <see cref="Func{TModel, object}"/> for ordering <see cref="TModel"/>
        /// </summary>
        public Func<TModel, object> KeySelector { get; private set; }

        /// <summary>
        /// Create instance of class
        /// </summary>
        /// <param name="orderType"><see cref="OrderType"/></param>
        /// <param name="keySelector"><see cref="Func{TModel, object}"/> for ordering <see cref="TModel"/></param>
        public OrderModel(OrderType orderType, Func<TModel, object> keySelector)
        {
            OrderType = orderType;
            KeySelector = keySelector;
        }
    }
}
