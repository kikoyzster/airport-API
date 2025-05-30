﻿namespace airport.Models.AirportInfoAPI.Response
{
    public class Shops
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
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
