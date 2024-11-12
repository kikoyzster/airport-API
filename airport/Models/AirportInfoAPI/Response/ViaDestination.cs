using Microsoft.AspNetCore.Mvc;

namespace airport.Models.AirportInfoAPI.Response
{
    public class ViaDestination
    {
        public string airportIATA { get; set; }
        public string airportSwedish { get; set; }
        public string airportEnglish { get; set; }
    }
}
