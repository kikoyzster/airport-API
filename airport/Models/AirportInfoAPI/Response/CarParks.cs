namespace airport.Models.AirportInfoAPI.Response
{
    public class CarParks
    {
        public string IATA { get; set; }
        public string AirportName { get; set; }
        public string Terminal { get; set; }
        public string CarParkName { get; set; }
        public bool IsSoldOut { get; set; }
        public string CategoryTag { get; set; }
        public string CategoryName { get; set; }
        public string ProductLabel { get; set; }
        public string TransferTime { get; set; }

        public string TransferMethod { get; set; }
        public string TransferType { get; set; }
        public string? MapImageUrl { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
