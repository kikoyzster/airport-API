using Microsoft.AspNetCore.Mvc;

namespace airport.Models.AirportInfoAPI.Response
{
    public class ArrivalTime
    {
        public string scheduledUtc { get; set; }
        public string estimatedUtc { get; set; }
        public string actualUtc { get; set; }
        public string scheduledUtcShort { get; set; }
    }
}
