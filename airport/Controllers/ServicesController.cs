using airport.Helper;
using airport.Models.AirportInfoAPI.Response;
using Microsoft.AspNetCore.Mvc;

namespace airport.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IApiService _apiService;

        public ServicesController(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IActionResult> Index()
        {
            string iata = HttpContext.Session.GetString("SelectedAirport");
            // Call with parameters
            var queryParams = new Dictionary<string, object>
            {
                 { "LangCode", "sv" },

            };

            var dataWithParams = await _apiService.GetDataAsync<List<Services>>($"airportinfo/v2/{iata}/services", queryParams);

            return View(dataWithParams);
            
        }
    }
}
