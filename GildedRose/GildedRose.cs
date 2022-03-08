using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (IsSulfuras(item))
                {                  
                }
                else if (IsGeneric(item))
                {
                    HandleGeneric(item);
                }
                else if (IsAgedBrie(item))
                {
                    HandleAgedBrie(item);
                }
                else if (IsBackstagePass(item))
                {
                    HandleBackstagePass(item);
                }                    
            }
        }

        private static void HandleAgedBrie(Item item)
        {
            if (IsQualityLessThan50(item))
            {
                IncreaseQuality(item);
            }
            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (IsQualityLessThan50(item))
                {
                    IncreaseQuality(item);
                }
            }
        }

        private static void HandleGeneric(Item item)
        {
            if (item.Quality > 0)
            {
                if (!IsSulfuras(item))
                {
                    DecreaseQuality(item);
                }
            }
            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    DecreaseQuality(item);
                }
            }
        }

        private static void HandleBackstagePass(Item item)
        {
            if (IsQualityLessThan50(item))
            {
                IncreaseQuality(item);

                if (item.SellIn < 11)
                {
                    if (IsQualityLessThan50(item))
                    {
                        IncreaseQuality(item);
                    }
                }

                if (item.SellIn < 6)
                {
                    if (IsQualityLessThan50(item))
                    {
                        IncreaseQuality(item);
                    }
                }
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - item.Quality;
            }
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

        private static bool IsQualityLessThan50(Item item)
        {
            return item.Quality < 50;
        }

        private static void IncreaseQuality(Item item)
        {
            item.Quality = item.Quality + 1;
        }

        private static void DecreaseQuality(Item item)
        {
            item.Quality = item.Quality - 1;
        }
    }
}
