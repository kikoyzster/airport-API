using airport.Helper;
using Microsoft.AspNetCore.Mvc;
using airport.Models.AirportInfoAPI.Response;

namespace airport.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IApiService _apiService;

        public RestaurantController(IApiService apiService)
        {
            _apiService = apiService;
        }

        
        public async Task<IActionResult> Index()
        {
            string iata = HttpContext.Session.GetString("SelectedAirport");
            string airportName = HttpContext.Session.GetString("SelectedAirportName");
            // Call with parameters
            var queryParams = new Dictionary<string, object>
            {
                 { "LangCode", "sv" },
                 
            };
    
            var dataWithParams = await _apiService.GetDataAsync<List<Restaurants>>($"airportinfo/v2/{iata}/restaurants", queryParams);
            ViewBag.AirportName = airportName; // Pass the airport name to the view
            return View(dataWithParams);
        }

        public async Task<IActionResult> LangCode() 
        {
            var dataWithoutParams = await _apiService.GetDataAsync<List<Languages>>("airportinfo/v2/languages");

            return View(dataWithoutParams); 
        }
    }
}
