namespace Inventory
{
    public class Generic : IGood
    {
        private Quality _quality;

        public Generic(int quality, int sellIn)
        {
            _quality = new Quality(quality);
            SellIn = sellIn;
        }

        public int Quality => _quality.Amount;

        public int SellIn { get; set; }

        public void Update()
        {
            _quality.Degrade();
            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                _quality.Degrade();
            }
        }
    }

}