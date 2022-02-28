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
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (Items[i].Quality > 0)
                    {
                        if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            DecreaseQuality(Items[i]);
                        }
                    }
                }
                else
                {
                    if (IsQualityLessThan50(Items[i]))
                    {
                        IncreaseQuality(Items[i]);

                        if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (IsQualityLessThan50(Items[i]))
                                {
                                    IncreaseQuality(Items[i]);
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (IsQualityLessThan50(Items[i]))
                                {
                                    IncreaseQuality(Items[i]);
                                }
                            }
                        }
                    }
                }

                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (Items[i].Name != "Aged Brie")
                    {
                        if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    DecreaseQuality(Items[i]);
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (IsQualityLessThan50(Items[i]))
                        {
                            IncreaseQuality(Items[i]);
                        }
                    }
                }
            }
        }

        private bool IsQualityLessThan50(Item item)
        {
            return item.Quality < 50;
        }

        private void IncreaseQuality(Item item)
        {
            item.Quality = item.Quality + 1;
        }

        private void DecreaseQuality(Item item)
        {
            item.Quality = item.Quality - 1;
        }
    }
}
