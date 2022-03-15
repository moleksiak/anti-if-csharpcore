using System.Collections.Generic;
using Inventory;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private readonly IList<Item> _items;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (IsSulfuras(item)) continue;

                item.SellIn -= 1;
                var quality = new Quality(item.Quality);
                var good = new GoodCategory().BuildFor(item);
                good.Update(quality);
                item.Quality = quality.Amount;    
            }
        }

        private static bool IsSulfuras(Item currentItem)
        {
            return currentItem.Name == "Sulfuras, Hand of Ragnaros";
        }
    }
}
