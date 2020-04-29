using System;
using System.Collections.Generic;
using System.Linq;
using FactoryProductSaver.Enums;
using FactoryProductSaver.Models;

namespace FactoryProductSaver.Core.Interfaces
{
    public abstract class OrderBase<TModel>: IOrder<TModel>
        where TModel: class

    {
        protected OrderModel<TModel>[] _orderModels;

        private int _currentIndex = 0;

        protected OrderBase(OrderModel<TModel>[] orderModels)
        {
            _orderModels = orderModels;
        }

        public IOrderedEnumerable<TModel> OrderBy(IEnumerable<TModel> items)
        {
            IOrderedEnumerable<TModel> orderedItems = null;

            var orderValueTuple = Next();

            switch (orderValueTuple.OrderType)
            {
                case OrderType.Asc:
                    orderedItems = items.OrderBy(orderValueTuple.KeySelector);
                    break;
                case OrderType.Desc:
                    orderedItems = items.OrderByDescending(orderValueTuple.KeySelector);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            orderValueTuple = Next();

            while (orderValueTuple != null)
            {
                switch (orderValueTuple.OrderType)
                {
                    case OrderType.Asc:
                        orderedItems = items.OrderBy(orderValueTuple.KeySelector);
                        break;
                    case OrderType.Desc:
                        orderedItems = items.OrderByDescending(orderValueTuple.KeySelector);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                orderValueTuple = Next();
            }

            _currentIndex = 0;
            return orderedItems;
        }
        
        private OrderModel<TModel> Next()
        {
            if (_orderModels.Length <= _currentIndex)
            {
                return null;
            }

            return _orderModels[_currentIndex++];
        }
    }
}
