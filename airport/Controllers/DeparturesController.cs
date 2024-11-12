using airport.Models;
using airport.Models.AirportInfoAPI.Response;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using airport.Helper;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.Http;

namespace airport.Controllers
{
    public class DeparturesController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IHttpClientFactory _httpClientFactory;


        public DeparturesController(IApiService apiService, IHttpClientFactory httpClientFactory)
        {
            _apiService = apiService;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(DateTime date, string time)
        {
            SubscriptionKeyFlightInfo subscriptionKeyFlightInfo = new SubscriptionKeyFlightInfo();
            var flightInfoKey = SubscriptionKeyFlightInfo.getKey();

            string iata = HttpContext.Session.GetString("SelectedAirport");
           // HttpContext.Session.SetString("SelectedArrivalDate", airportCode ?? "Default");

            if (date == DateTime.MinValue)
            {
                date = DateTime.Now;
            }
            if (string.IsNullOrEmpty(time) || time == "default")
            {
                time = DateTime.Now.ToShortTimeString();
            }
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://api.swedavia.se/");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", flightInfoKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

            var _url = $"https://api.swedavia.se/flightinfo/v2/{iata}/departures/{date:yyyy-MM-dd}";


            var departures = await client.GetFromJsonAsync<Departures>(_url);
            departures.selectedDateStr = date.ToShortDateString();
            departures.selectedTimeStr = time;
            return View(departures);
        }
        public async Task<IActionResult> FlightInfo(DepartureFlight departureFlight)
        {
            SubscriptionKeyFlightInfo subscriptionKeyFlightInfo = new SubscriptionKeyFlightInfo();
            var flightInfoKey = SubscriptionKeyFlightInfo.getKey();

            string iata = HttpContext.Session.GetString("SelectedAirport");
            // HttpContext.Session.SetString("SelectedArrivalDate", airportCode ?? "Default");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://api.swedavia.se/");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", flightInfoKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

            DateTime date = DateTime.Parse(departureFlight.scheduledUtc);
            var _url = $"https://api.swedavia.se/flightinfo/v2/{iata}/departures/{date:yyyy-MM-dd}";
            

            var departures = await client.GetFromJsonAsync<Departures>(_url);
            DepartureFlight selectedFlight = departures.flights.Where(flight => flight.flightId == departureFlight.flightId).FirstOrDefault();
            selectedFlight.departureTime.scheduledUtcShort = DateTime.Parse(departureFlight.scheduledUtc).ToShortTimeString();
            return View(selectedFlight);
        }

        public async Task<IActionResult> ResponseTest()
        {
            var iataCode = "OSD"; // Extracted from the first dictionary
            var queryParams = new Dictionary<string, object>
        {
            { "StartMonth", 1 },
            { "EndMonth", 2 },
            { "Minimum Number", 10 }
        };
            var dataWithParams = await _apiService.GetDataAsync<List<CityDestination>>($"airportinfo/v2/{iataCode}/destinations", queryParams);
            return View(dataWithParams);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task OnGetAsync(string airportIATA, DateTime date)
        {
            SubscriptionKeyFlightInfo subscriptionKeyFlightInfo = new SubscriptionKeyFlightInfo();
            var flightInfoKey = SubscriptionKeyFlightInfo.getKey();
            
            var AirportIATA = "GOT";//arportIATA;
            var Date = DateTime.Now;//date;

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://api.swedavia.se/");
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", flightInfoKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");

            var _url = $"https://api.swedavia.se/flightinfo/v2/{AirportIATA}/arrivals/{Date:yyyy-MM-dd}";
            //var _url = "https://api.swedavia.se/flightinfo/v2/GOT/arrivals/2024-05-10";
            //var response = await client.GetAsync(_url);
            //var stringResponse = await response.Content.ReadAsStringAsync();

            var arrivals = await client.GetFromJsonAsync<Arrivals>(_url);
            //var response = await client.GetFromJsonAsync<IEnumerable<FlightArrival>>(
            //    $"https://api.swedavia.se/flightinfo/v2/{airportIATA}/arrivals/{date:yyyy-MM-dd}");

            //Arrivals = response ?? new List<FlightArrival>();
        }
    }
}
