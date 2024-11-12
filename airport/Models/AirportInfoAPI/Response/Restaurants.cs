namespace airport.Models.AirportInfoAPI.Response
{
    public class Restaurants
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Telephone { get; set; }
        public string OpeningHours { get; set; }
        public string PhotoImgUrl { get; set; }
        public string AppImgUrl { get; set; }
        public Location Location { get; set; }
        public string AirportIata { get; set; }
        public List<Category> Categories { get; set; }
        public string[] Keywords { get; set; }

    }
}
