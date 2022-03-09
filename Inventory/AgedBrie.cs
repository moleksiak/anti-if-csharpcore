namespace Inventory
{
    public class AgedBrie : IGood
    {
        private readonly Quality _quality;

        public AgedBrie(int quality, int sellIn)
        {
            _quality = new Quality(quality);
            SellIn = sellIn;
        }

        public int Quality => _quality.Amount;
        public int SellIn { get; set; }

        public void Update()
        {
            _quality.Increase();
            
            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                _quality.Increase();
            }
        }
    }
}