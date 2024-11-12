using Microsoft.AspNetCore.Mvc;

namespace airport.Models.AirportInfoAPI.Response
{
    public class DepartureLocationAndStatus
    {
        public string terminal { get; set; }
        public string gate { get; set; }
        public string gateAction { get; set; }
        public string gateOpenUtc { get; set; }
        public string gateCloseUtc { get; set; }
        public string flightLegStatus { get; set; }
        public string flightLegStatusSwedish { get; set; }
        public string flightLegStatusEnglish { get; set; }
    }
}
