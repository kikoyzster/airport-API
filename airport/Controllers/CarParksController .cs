using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using airport.Helper;
using airport.Models.AirportInfoAPI.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace airport.Controllers
{
    public class CarParksController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CarParksController(IApiService apiService, IHttpContextAccessor httpContextAccessor)
        {
            _apiService = apiService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            // Get the IATA code and airport name from the session
            string iata = _httpContextAccessor.HttpContext.Session.GetString("SelectedAirport");
            string airportName = _httpContextAccessor.HttpContext.Session.GetString("SelectedAirportName");

            if (string.IsNullOrEmpty(iata))
            {
                ViewBag.ErrorMessage = "IATA code is missing.";
                return View("Error");
            }

            if (string.IsNullOrEmpty(airportName))
            {
                ViewBag.ErrorMessage = "Airport name is missing.";
                return View("Error");
            }

            // Call the API to get car parks data
            var endpoint = $"airportinfo/v2/{iata}/parkinglots";
            var queryParams = new Dictionary<string, object>
    {
        { "startDate", DateTime.UtcNow.AddDays(1).ToString("yyyy-MM-dd") },
        { "endDate", DateTime.UtcNow.AddDays(3).ToString("yyyy-MM-dd") }
    };

            try
            {
                var parkingResponse = await _apiService.GetDataAsync<Parking>(endpoint, queryParams);

                if (parkingResponse == null || parkingResponse.CarParks == null)
                {
                    ViewBag.ErrorMessage = "No car parks data found.";
                    return View("Error");
                }

                // Optionally convert TransferTime to DateTime
                foreach (var carPark in parkingResponse.CarParks)
                {
                    DateTime transferTime;
                    if (DateTime.TryParse(carPark.TransferTime, out transferTime))
                    {
                        carPark.TransferTime = transferTime.ToString("HH:mm");
                    }
                }

                // Pass the data to the view
                ViewBag.AirportName = airportName;
                return View(parkingResponse.CarParks);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"An error occurred: {ex.Message}";
                return View("Error");
            }
        }

    }
}
