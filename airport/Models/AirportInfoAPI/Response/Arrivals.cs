using Microsoft.AspNetCore.Mvc;

namespace airport.Models.AirportInfoAPI.Response
{
    public class Arrivals
    {
        public To to { get; set; }
        public int numberOfFlights { get; set; }
        public ArrivalFlight[]? flights { get; set; }
        public string selectedDateStr { get; set; }
        public string selectedTimeStr { get; set; }
    }
}
