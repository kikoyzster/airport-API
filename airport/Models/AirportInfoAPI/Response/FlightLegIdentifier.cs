using Microsoft.AspNetCore.Mvc;

namespace airport.Models.AirportInfoAPI.Response
{
    public class FlightLegIdentifier
    {
        public string ifplId { get; set; }
        public string callsign { get; set; }
        public string aircraftRegistration { get; set; }
        public string ssrCode { get; set; }
        public string flightId { get; set; }
        public string flightDepartureDateUtc { get; set; }
        public string departureAirportIata { get; set; }
        public string arrivalAirportIata { get; set; }
        public string departureAirportIcao { get; set; }
        public string arrivalAirportIcao { get; set; }
    }
}
