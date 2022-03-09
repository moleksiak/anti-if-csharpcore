namespace Inventory
{
    public class BackstagePass : IGood
    {
        private readonly Quality _quality;

        public BackstagePass(int quality, int sellIn)
        {
            _quality = new Quality(quality);
            SellIn = sellIn;
        }

        public int Quality => _quality.Amount;
        public int SellIn { get; set; }

        public void Update()
        {
            _quality.Increase();

            if (_quality.IsLessThan50())
            {
                if (SellIn < 11)
                {
                    _quality.Increase();
                }

                if (SellIn < 6)
                {
                    _quality.Increase();
                }
            }

            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                _quality.Reset();                
            }
        }
    }
}