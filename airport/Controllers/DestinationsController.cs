using Microsoft.AspNetCore.Mvc;
using airport.Helper;
using airport.Models.AirportInfoAPI.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace airport.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly IApiService _apiService;

        public DestinationsController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            string iata = HttpContext.Session.GetString("SelectedAirport");
            string airportName = HttpContext.Session.GetString("SelectedAirportName");

            if (string.IsNullOrEmpty(iata))
            {
                ViewBag.ErrorMessage = "No airport selected.";
                return View("Error");
            }

            var queryParams = new Dictionary<string, object>
            {
                { "startMonth", DateTime.UtcNow.Month },
                { "endMonth", DateTime.UtcNow.AddMonths(1).Month },
                { "minimumDepartures", 5 }
            };

            var endpoint = $"airportinfo/v2/{iata}/destinations";
            var data = await _apiService.GetDataAsync<List<CityDestination>>(endpoint, queryParams);

            if (data == null)
            {
                ViewBag.ErrorMessage = "Could not retrieve destination data.";
                return View("Error");
            }
            ViewBag.AirportName = airportName;
            return View(data);
        }
    }
}
