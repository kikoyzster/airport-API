using Microsoft.AspNetCore.Mvc;
using airport.Helper;
using airport.Models.WaitTimeAPI.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace airport.Controllers
{
    public class SecurityWaitTimeController : Controller
    {
        private readonly IApiService _apiService;
        private readonly List<string> supportedAirports = new List<string> { "ARN", "BMA", "GOT" };

        public SecurityWaitTimeController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            string iata = HttpContext.Session.GetString("SelectedAirport");
            string airportName = HttpContext.Session.GetString("SelectedAirportName");

            if (string.IsNullOrEmpty(iata) || !supportedAirports.Contains(iata))
            {
                ViewBag.ErrorMessage = "The selected airport is not supported for security wait time information.";
                return View("Error");
            }

            var endpoint = $"waittimepublic/v2/airports/{iata}";
            var data = await _apiService.GetDataAsync<WaitTimeResponse>(endpoint);

            ViewBag.AirportIata = iata;
            ViewBag.AirportName = airportName;
            return View(data);
        }
    }
}
