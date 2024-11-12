namespace airport.Models.AirportInfoAPI.Response
{
    public class Operator
    {
        public string Name { get; set; }
        public string Icao { get; set; }
        public string Iata { get; set; }
        public int OccuredTimes { get; set; }
        public bool CharterFlights { get; set; }
        public bool RegularFlights { get; set; }
    }
}
