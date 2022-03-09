namespace Inventory
{
    internal class Quality
    {
        private int _amount;

        public Quality(int amount)
        {
            _amount = amount;
        }

        public int Amount => _amount;

        public void Degrade()
        {
            if (_amount > 0)
            {
                _amount -= 1;
            }
        }

        internal void Increase()
        {
            if (_amount < 50)
            {
                _amount += 1;
            }
        }

        internal bool IsLessThan50()
        {
            return _amount < 50;
        }

        internal void Reset()
        {
            _amount = 0;
        }
    }
}
