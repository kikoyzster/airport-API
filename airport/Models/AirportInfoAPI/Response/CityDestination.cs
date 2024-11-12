using Microsoft.Build.Evaluation;

namespace airport.Models.AirportInfoAPI.Response
{
    public class CityDestination
    {
        public string IATA { get; set; }
        public int OccuredTimes { get; set; }
        public double LatitudeAirport { get; set; }
        public double LongitudeAirport { get; set; }
        public string CodeIataCity { get; set; }
        public List<Operator> Operators { get; set; }
    }


}
