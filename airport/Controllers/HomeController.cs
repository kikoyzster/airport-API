using airport.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using airport.Helper;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using airport.Models.AirportInfoAPI.Response;

namespace airport.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiService _apiService;

        public HomeController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public IActionResult Airport()
        {
           // // Call without parameters
           // var dataWithoutParams = await _apiService.GetDataAsync<List<Airport>>("airportinfo/v2/airports");

           // // Call with parameters
           // var queryParams = new Dictionary<string, object>
           //{
           //     { "Airport IATA", "ARN" },
           //     { "StartMonth", 1 },
           //     { "EndMonth", 12 },
           //     { "Minimum Number", 10 }
           //};
           // var dataWithParams = await _apiService.GetDataAsync<List<Airport>>("airportinfo/v2/airports", queryParams);
           // //försökte en ny metod i ApiService2.cs fungerar inte
           //ApiService2 apiService = new ApiService2();
           // var response = await apiService.GetApiResponse<Airport>(endpoint: "airportinfo/v2/airports");
           // //Combine or process the data as needed
           // return View(dataWithoutParams);
            return View();
        }
        public async Task<IActionResult> Menu(string airportCode = null, string name = null)
        {
            // Set the airport code and name in the session
            HttpContext.Session.SetString("SelectedAirport", airportCode ?? "Default");
            HttpContext.Session.SetString("SelectedAirportName", name ?? "DefaultName");

            ViewBag.AirportName = name;
            return View();
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

        public IActionResult SelectAirport(string iata, string name)
        {
            if (string.IsNullOrEmpty(iata) || string.IsNullOrEmpty(name))
            {
                return View("Error");
            }

            
            HttpContext.Session.SetString("SelectedAirportIata", iata);
            HttpContext.Session.SetString("SelectedAirportName", name);

            return RedirectToAction("Options");
        }

        public IActionResult Options()
        {
            
            ViewBag.Iata = HttpContext.Session.GetString("SelectedAirportIata");
            ViewBag.Name = HttpContext.Session.GetString("SelectedAirportName");

            return View();
        }


    }
}
