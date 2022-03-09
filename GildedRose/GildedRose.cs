using System;
using System.Collections.Generic;
using Inventory;

namespace GildedRoseKata
{
    public class GildedRose
    {
        class GoodCategory
        {
            public IGood BuildFor(Item item)
            {
                if (IsSulfuras(item))
                {
                    return new Sulfuras(item.Quality, item.SellIn);
                }
                else if (IsGeneric(item))
                {
                    return new Generic(item.Quality, item.SellIn);
                }
                else if (IsAgedBrie(item))
                {
                    return new AgedBrie(item.Quality, item.SellIn);
                }
                else if (IsBackstagePass(item))
                {
                    return new BackstagePass(item.Quality, item.SellIn);
                }

                throw new NotSupportedException();
            }

            private static bool IsGeneric(Item item)
            {
                return !(IsSulfuras(item) || IsAgedBrie(item) || IsBackstagePass(item));
            }

            private static bool IsSulfuras(Item currentItem)
            {
                return currentItem.Name == "Sulfuras, Hand of Ragnaros";
            }

            private static bool IsBackstagePass(Item item)
            {
                return item.Name == "Backstage passes to a TAFKAL80ETC concert";
            }

            private static bool IsAgedBrie(Item item)
            {
                return item.Name == "Aged Brie";
            }
        }

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var good = new GoodCategory().BuildFor(item);
                good.Update();
                item.Quality = good.Quality;
                item.SellIn = good.SellIn;               
            }
        }
    }
}
