using Microsoft.AspNetCore.Mvc;

namespace airport.Models.AirportInfoAPI.Response
{
    public class Baggage
    {
        public string estimatedFirstBagUtc { get; set; }
        public string baggageClaimUnit { get; set; }
        public string firstBagUtc { get; set; }
        public string lastBagUtc { get; set; }
    }
}
