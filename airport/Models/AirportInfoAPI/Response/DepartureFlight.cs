using Microsoft.AspNetCore.Mvc;

namespace airport.Models.AirportInfoAPI.Response
{
    public class DepartureFlight
    {
        public string flightId { get; set; }
        public string arrivalAirportSwedish { get; set; }
        public string arrivalAirportEnglish { get; set; }
        public Operator airlineOperator { get; set; }
        public DepartureTime departureTime { get; set; }
        public DepartureLocationAndStatus locationAndStatus { get; set; }
        public CheckIn checkIn { get; set; }
        public string[] codeShareData { get; set; }
        public FlightLegIdentifier flightLegIdentifier { get; set; }
        public ViaDestination[] viaDestination { get; set; }
        public Remark[] remarksEnglish { get; set; }
        public Remark[] remarksSwedish { get; set; }
        public string diIndicator { get; set; }
        public string scheduledUtc { get; set; }
    }
}
