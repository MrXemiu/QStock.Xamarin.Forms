using System;
using System.Collections.Generic;
using System.Linq;

namespace QStock.Xamarin.Core.Util
{
    public static class ModelExtensions
    {
        #region Public Methods

        //public static bool StockCodeMatches(this IInventoryItem item, string stockcode)
        //{
        //    return item.BaseItem.StockCode.Equals(stockcode, StringComparison.OrdinalIgnoreCase);
        //}

        //public static bool StockCodeMatches(this AbstractInventoryItem item, string stockcode)
        //{
        //    return item.StockCode.Equals(stockcode, StringComparison.OrdinalIgnoreCase);
        //}

        //public static bool NumberMatches(this PurchaseOrder order, string poNumber)
        //{
        //    return order.Number.Equals(poNumber, StringComparison.OrdinalIgnoreCase);
        //}

        //public static bool NumberMatches(this PickTicket pickTicket, string salesOrderNumber)
        //{
        //    return pickTicket.Number.Equals(salesOrderNumber, StringComparison.OrdinalIgnoreCase);
        //}

        //public static bool BinNameMatches(this Bin bin, string binName)
        //{
        //    return bin.BinLoc.Equals(binName, StringComparison.OrdinalIgnoreCase);
        //}

        //public static bool Equals(this IInventoryItem item, IInventoryItem other)
        //{
        //    var comparer = new InventoryItemEqualityComparer();
        //    return comparer.Equals(item, other);
        //}

        //public static IEnumerable<BinContentsListItemViewModel> ToBinContentsListItemViewModels(this IEnumerable<StockInventoryItem> stockItems)
        //{
        //    var binItems = (from s in stockItems
        //                    group s by new { s.BaseItem.StockCode, s.PackSize.BaseUnit } into g
        //                    select new BinContentsListItemViewModel { StockCode = g.Key.StockCode, BaseUnit = g.Key.BaseUnit, BaseQty = g.Sum(item => item.BaseQuantity) });
        //    return binItems;
        //}

        #endregion Public Methods
    }
}