using Microsoft.AspNetCore.Mvc;

namespace airport.Models.AirportInfoAPI.Response
{
    public class CheckIn
    {
        public string checkInStatus { get; set; }
        public string checkInStatusSwedish { get; set; }
        public string checkInStatusEnglish { get; set; }
        public int checkInDeskFrom { get; set; }
        public int checkInDeskTo { get; set; }
    }
}
