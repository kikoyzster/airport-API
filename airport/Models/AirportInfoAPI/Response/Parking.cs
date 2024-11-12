namespace airport.Models.AirportInfoAPI.Response
{
    public class Parking
    {
        public List<CarParks> CarParks { get; set; }

        // returnar en länk för att beställa parkeringsplats ANVÄND EJ!
        //public string BookingInformationLink { get; set; }
    }
}
