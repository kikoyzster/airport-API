using Microsoft.AspNetCore.Mvc;

namespace airport.Models.AirportInfoAPI.Response
{
    public class From
    {
        public string? departureAirportIata { get; set; }
        public string? departureAirportIcao { get; set; }
        public string? departureAirportSwedish { get; set; }
        public string? departureAirportEnglish { get; set; }
        public string? flightDepartureDate { get; set; }
    }
}
