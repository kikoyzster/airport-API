using Microsoft.AspNetCore.Mvc;

namespace airport.Models.AirportInfoAPI.Response
{
    public class To
    {
        public string? arrivalAirportIata { get; set; }
        public string? arrivalAirportIcao { get; set; }
        public string? arrivalAirportSwedish { get; set; }
        public string? arrivalAirportEnglish { get; set; }
        public string? flightArrivalDate { get; set; }
    }
}
