using airport.Models;

namespace airport.Helper
{
    public class AirportInfoSubscriptionKeyStrategy : ISubscriptionKeyStrategy
    {
        public bool CanHandle(string endpoint) => endpoint.StartsWith("airportinfo");
        public string GetKey() => SubscriptionKeyAirportInfo.getKey();
    }
    public class FlightInfoSubscriptionKeyStrategy : ISubscriptionKeyStrategy
    {
        public bool CanHandle(string endpoint) => endpoint.StartsWith("flightinfo");
        public string GetKey() => SubscriptionKeyFlightInfo.getKey();
    }

    public class WaitTimePublicSubscriptionKeyStrategy : ISubscriptionKeyStrategy
    {
        public bool CanHandle(string endpoint) => endpoint.StartsWith("waittimepublic");
        public string GetKey() => SubscriptionKeyWaitTime.getKey();
    }
}
