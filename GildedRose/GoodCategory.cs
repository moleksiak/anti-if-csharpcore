using System;
using Inventory;

namespace GildedRoseKata
{
    internal class GoodCategory
    {
        public IGood BuildFor(Item item)
        {
            switch (item.Name)
            {
                case "Backstage passes to a TAFKAL80ETC concert":
                    return BackstagePass.Build(item.SellIn);
                case "Aged Brie":
                    return AgedBrie.Build(item.SellIn);
                default:
                    return Generic.Build(item.SellIn);
            }
        }
    }
}
