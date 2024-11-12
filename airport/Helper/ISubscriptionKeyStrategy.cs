namespace airport.Helper
{
    public interface ISubscriptionKeyStrategy
    {
        bool CanHandle(string endpoint);
        string GetKey();
    }
}
