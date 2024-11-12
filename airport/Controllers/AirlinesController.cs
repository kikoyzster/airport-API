using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using airport.Helper;
using airport.Models.AirportInfoAPI.Response;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace airport.Controllers
{
    public class AirlinesController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AirlinesController(IApiService apiService)
        {
            _apiService = apiService;
        }


        public async Task<IActionResult> Index()
        {
            string iata = HttpContext.Session.GetString("SelectedAirport");
            string airportName = HttpContext.Session.GetString("SelectedAirportName");

            if (string.IsNullOrEmpty(iata))
            {
                return View("Error");
            }

            var endpoint = $"airportinfo/v2/airlines";
            var queryParams = new Dictionary<string, object>
            {
                { "airport", iata }
            };

            List<Airlines> data;

            data = await _apiService.GetDataAsync<List<Airlines>>(endpoint, queryParams);

            ViewBag.AirportName = airportName;

            return View(data);
        }
    }
}
