using Microsoft.AspNetCore.Mvc;

namespace airport.Models.AirportInfoAPI.Response
{
    public class Departures
    {
        public From from { get; set; }
        public int numberOfFlights { get; set; }
        public DepartureFlight[]? flights { get; set; }
        public string selectedDateStr { get; set; }
        public string selectedTimeStr { get; set; }
    }
}
