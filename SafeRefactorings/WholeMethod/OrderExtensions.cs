using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SafeRefactorings.Models;

namespace SafeRefactorings.WholeMethod
{
    public static class OrderExtensions
    {
        public static PriceCategory GetPriceCategory(this Order order)
        {
            if (order == null)
            {
                return PriceCategory.Invalid;
            }

            if (order.Price < 0)
            {
                return PriceCategory.Invalid;
            }
            if (order.Price >= 0 && order.Price < 101)
            {
                return PriceCategory.Cheap;
            }
            if (order.Price >= 101 && order.Price < 201)
            {
                return PriceCategory.NotSoCheap;
            }
            if (order.Price >= 201 && order.Price < 301)
            {
                return PriceCategory.Average;
            }
            if (order.Price >= 301 && order.Price < 401)
            {
                return PriceCategory.SlightlyExpensive;
            }
            return PriceCategory.Expensive;
        }

        public static PriceCategory DetermineCategory(this Order order)
        {
            switch (order.Price)
            {
                case var price when price < 0:
                    return PriceCategory.Invalid;
                case var price when price < 101:
                    return PriceCategory.Cheap;
                case var price when price < 201:
                    return PriceCategory.NotSoCheap;
                case var price when price < 310:
                    return PriceCategory.Average;
                case var price when price < 401:
                    return PriceCategory.SlightlyExpensive;
                default:
                    return PriceCategory.Expensive;
            }
        }
    }
}
