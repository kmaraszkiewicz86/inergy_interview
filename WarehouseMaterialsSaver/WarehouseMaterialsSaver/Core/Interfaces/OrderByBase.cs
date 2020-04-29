using System;
using System.Collections.Generic;
using System.Linq;
using WarehouseMaterialsSaver.Enums;
using WarehouseMaterialsSaver.Models;

namespace WarehouseMaterialsSaver.Core.Interfaces
{
    /// <summary>
    /// Abstract class for ordering functionality
    /// </summary>
    /// <typeparam name="TModel"><see cref="TModel"/></typeparam>
    public abstract class OrderByBase<TModel>: IOrderBy<TModel>
        where TModel: class

    {
        /// <summary>
        /// Data about ordering steps to execute
        /// </summary>
        protected OrderModel<TModel>[] _orderModels;

        /// <summary>
        /// Get current <see cref="_orderModels"/>
        /// </summary>
        private OrderModel<TModel> _currentOrderModel =>
            _orderModels[_currentIndex];

        /// <summary>
        /// Current <see cref="_orderModels"/> index
        /// </summary>
        private int _currentIndex = 0;

        /// <summary>
        /// Initialize class
        /// </summary>
        /// <param name="orderModels">Steps for ordering steps to execute by class</param>
        protected OrderByBase(OrderModel<TModel>[] orderModels)
        {
            _orderModels = orderModels;
        }

        /// <summary>
        /// Execute n orders step depend on <see cref="_orderModels"/> definition
        /// </summary>
        /// <param name="items">Items for sorting</param>
        /// <returns></returns>
        public IOrderedEnumerable<TModel> Execute(IEnumerable<TModel> items)
        {
            IOrderedEnumerable<TModel> orderedItems = OrderBy(items);

            OrderModel<TModel> orderModel = Next();

            while (orderModel != null)
            {
                orderedItems = Then(orderedItems);
                orderModel = Next();
            }

            _currentIndex = 0;
            return orderedItems;
        }

        /// <summary>
        /// First step for ordering not ordered items
        /// </summary>
        /// <param name="items"></param>
        /// <returns><see cref="IOrderedEnumerable{TModel}"/> ordered items</returns>
        private IOrderedEnumerable<TModel> OrderBy(IEnumerable<TModel> items)
        {
            switch (_currentOrderModel.OrderType)
            {
                case OrderType.Asc:
                    return items.OrderBy(_currentOrderModel.KeySelector);
                case OrderType.Desc:
                    return items.OrderByDescending(_currentOrderModel.KeySelector);
                default:
                    throw new NotSupportedException($"The {_currentOrderModel.OrderType} is not supported");
            }
        }

        /// <summary>
        /// Next steps for ordering ordered items
        /// </summary>
        /// <param name="orderedItems">Items for ordering process</param>
        /// <returns><see cref="IOrderedEnumerable{TModel}"/> ordered items</returns>
        private IOrderedEnumerable<TModel> Then(IOrderedEnumerable<TModel> orderedItems)
        {
            switch (_currentOrderModel.OrderType)
            {
                case OrderType.Asc:
                    return orderedItems.ThenBy(_currentOrderModel.KeySelector);
                case OrderType.Desc:
                    return orderedItems.ThenByDescending(_currentOrderModel.KeySelector);
                default:
                    throw new NotSupportedException($"The {_currentOrderModel.OrderType} is not supported");
            }
        }

        /// <summary>
        /// Move to next element <see cref="_orderModels"/> or return null if no
        /// elements left
        /// </summary>
        /// <returns>Next element or null object</returns>
        private OrderModel<TModel> Next()
        {
            if (_orderModels.Length <= ++_currentIndex)
            {
                return null;
            }

            return _orderModels[_currentIndex];
        }
    }
}