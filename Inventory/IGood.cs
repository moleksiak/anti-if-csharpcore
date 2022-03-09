namespace Inventory
{
    public interface IGood
    {
        void Update();
        int Quality { get; }
        int SellIn { get; }
    }
}