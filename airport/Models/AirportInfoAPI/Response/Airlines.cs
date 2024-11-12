using Microsoft.AspNetCore.Mvc;

namespace airport.Models.AirportInfoAPI.Response
{
    public class Airlines
    {
        public string IATA { get; set; }
        public string IACO { get; set; }
        public string Name { get; set; }
    }
}
