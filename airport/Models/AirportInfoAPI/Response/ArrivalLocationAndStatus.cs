using Microsoft.AspNetCore.Mvc;

namespace airport.Models.AirportInfoAPI.Response
{
    public class ArrivalLocationAndStatus
    {
        public string terminal { get; set; }
        public string gate { get; set; }
        public string flightLegStatus { get; set; }
        public string flightLegStatusSwedish { get; set; }
        public string flightLegStatusEnglish { get; set; }
    }
}
