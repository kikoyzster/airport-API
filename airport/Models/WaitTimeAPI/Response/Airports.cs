using Newtonsoft.Json;

namespace airport.Models.WaitTimeAPI.Response
{
    
    public class Airports
    {
        public int Id { get; set; }
        public string QueueName { get; set; }
        public string CurrentTime { get; set; }
        public int CurrentProjectedWaitTime { get; set; }
        public bool IsFastTrack { get; set; }
        public string Terminal { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool Overflow { get; set; }

    }

    public class WaitTimeResponse
    {
        public int ActiveMeasurementStations { get; set; }
        public List<Airports> WaitTimes { get; set; }
    }
}
