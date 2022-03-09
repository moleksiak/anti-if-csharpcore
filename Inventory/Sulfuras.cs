namespace Inventory
{
    public class Sulfuras : IGood
    {
        public Sulfuras(int quality, int sellIn)
        {
            Quality = quality;
            SellIn = sellIn;
        }

        public int Quality { get; set; }
        public int SellIn { get; set; }

        public void Update()
        {
        }
    }
}