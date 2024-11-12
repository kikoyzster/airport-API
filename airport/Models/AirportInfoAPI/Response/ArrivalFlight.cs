using Microsoft.AspNetCore.Mvc;

namespace airport.Models.AirportInfoAPI.Response
{
    public class ArrivalFlight
    {
        public string flightId { get; set; }
        public string departureAirportSwedish { get; set; }
        public string departureAirportEnglish { get; set; }
        public Operator airlineOperator { get; set; }
        public ArrivalTime arrivalTime { get; set; }
        public ArrivalLocationAndStatus locationAndStatus { get; set; }
        public Baggage baggage { get; set; }
        public string[] codeShareData { get; set; }
        public FlightLegIdentifier flightLegIdentifier { get; set; }
        public Remark[] remarksEnglish { get; set; }
        public Remark[] remarksSwedish { get; set; }
        public ViaDestination[] viaDestination { get; set; }
        public string diIndicator { get; set; }
        public string scheduledUtc { get; set; }
    }
}
