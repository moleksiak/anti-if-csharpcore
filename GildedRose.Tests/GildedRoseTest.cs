using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using FluentAssertions;
using System.Linq;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }

        [Theory]
        [InlineData(22, 8, 20)]
        [InlineData(23, 4, 20)]
        [InlineData(0, 0, 20)]
        [InlineData(23, 1, 20)]
        [InlineData(22, 6, 20)]
        [InlineData(23, 5, 20)]
        [InlineData(21, 11, 20)]
        [InlineData(22, 10, 20)]
        public void AssertBackstagePassQuality(int expectedQuality, int sellIn, int initialQuality)
        {            
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert", 
                    SellIn = sellIn, 
                    Quality = initialQuality
                } 
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items.First().Quality.Should().Be(expectedQuality);
        }

        [Theory]
        [InlineData(22, 0, 20)]
        [InlineData(21, 1, 20)]
        public void AssertAgedBrieQuality(int expected, int sellIn, int initialQuality)
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = sellIn,
                    Quality = initialQuality
                }
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items.First().Quality.Should().Be(expected);
        }

        [Theory]
        [InlineData(18, 0, 20)]
        [InlineData(19, 1, 20)]
        [InlineData(1, -1, 3)]
        [InlineData(0, 1, 0)]
        public void AssertGenericQuality(int expected, int sellIn, int initialQuality)
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "foo",
                    SellIn = sellIn,
                    Quality = initialQuality
                }
            };

            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items.First().Quality.Should().Be(expected);
        }

        [Fact]
        public void ReportShowsCorrectly()
        {
            var reportLines = new List<string>();

            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                // this conjured item does not work properly yet
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(Items);

            int days = 2;

            reportLines.Add("OMGHAI!");

            for (var i = 0; i < days; i++)
            {
                reportLines.Add("-------- day " + i + " --------");
                reportLines.Add("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    reportLines.Add(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                reportLines.Add("");
                app.UpdateQuality();
            }

            var expectedReport = new List<string>() {
                "OMGHAI!",
                "-------- day 0 --------",
                "name, sellIn, quality",
                "+5 Dexterity Vest, 10, 20",
                "Aged Brie, 2, 0",
                "Elixir of the Mongoose, 5, 7",
                "Sulfuras, Hand of Ragnaros, 0, 80",
                "Sulfuras, Hand of Ragnaros, -1, 80",
                "Backstage passes to a TAFKAL80ETC concert, 15, 20",
                "Backstage passes to a TAFKAL80ETC concert, 10, 49",
                "Backstage passes to a TAFKAL80ETC concert, 5, 49",
                "Conjured Mana Cake, 3, 6",
                "",
                "-------- day 1 --------",
                "name, sellIn, quality",
                "+5 Dexterity Vest, 9, 19",
                "Aged Brie, 1, 1",
                "Elixir of the Mongoose, 4, 6",
                "Sulfuras, Hand of Ragnaros, 0, 80",
                "Sulfuras, Hand of Ragnaros, -1, 80",
                "Backstage passes to a TAFKAL80ETC concert, 14, 21",
                "Backstage passes to a TAFKAL80ETC concert, 9, 50",
                "Backstage passes to a TAFKAL80ETC concert, 4, 50",
                "Conjured Mana Cake, 2, 5",
                ""
            };

            expectedReport.Should().BeEquivalentTo(reportLines);
        }
    }
}
