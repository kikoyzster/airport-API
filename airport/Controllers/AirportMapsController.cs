using Microsoft.AspNetCore.Mvc;

using airport.Helper;

namespace airport.Controllers
{
    public class AirportMapsController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AirportMapsController(IApiService apiService, IHttpContextAccessor httpContextAccessor)
        {
            _apiService = apiService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            
            string airportName = HttpContext.Session.GetString("SelectedAirportName");

            if (string.IsNullOrEmpty(airportName))
            {
                
                return View("Error");
            }

            
            string imageUrl = GetAirportMapImageUrl(airportName);

            
            ViewBag.AirportName = airportName;
            ViewBag.ImageUrl = imageUrl;

            return View();
        }

        
        private string GetAirportMapImageUrl(string airportName)
        {
            
            switch (airportName)
            {
                case "Stockholm Arlanda Airport":
                    return "https://swedavia.imagevault.media/publishedmedia/rnwbotxpqfygdo2403be/ARN_oversiktskarta.png";
                case "Göteborg Landvetter Airport":
                    return "https://swedavia.imagevault.media/publishedmedia/3virm4byqpdgi9j38318/GOT_2592x2000px.jpg";
                case "Bromma Stockholm Airport":
                    return "https://swedavia.imagevault.media/publishedmedia/zyevs74r2t78ovxjfc2b/BMA_A42022.jpg";
                case "Malmö Airport":
                    return "https://swedavia.imagevault.media/publishedmedia/bnokg0rn043cgj2gi5m6/MMX_2592x2000px-2-.jpg";
                case "Luleå Airport":
                    return "https://swedavia.imagevault.media/publishedmedia/5cxjad7gd3tgpzmcyx6c/Reklamplatskarta_LLA_red1.png";
                case "Umeå Airport":
                    return "https://swedavia.imagevault.media/publishedmedia/oeuvg9i4bfs31t2vpjg6/Reklamplatskarta_UME_red1.png";
                case "Åre Östersund Airport":
                    return "https://swedavia.imagevault.media/publishedmedia/ocehep6nn29ll3lsqj7h/Reklamplatskarta_OSD_red1.png";
                case "Visby Airport":
                    return "https://swedavia.imagevault.media/publishedmedia/y4ma79i1gth1q4u1geaj/Reklamplatskarta_VBY_red1.png";
                case "Ronneby Airport":
                    return "https://swedavia.imagevault.media/publishedmedia/cdxg80x6jvfuvvefobd0/Reklamplatskarta_RNB_red1.png";
                case "Kiruna Airport":
                    return "https://swedavia.imagevault.media/publishedmedia/kajukeba9nlakh2k1tng/Karta_KRN.jpg";
                
                default:
                    
                    return "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRAKXJ2ZnTcwSAuUAztcL2gduO1l7v01wf427kvQfgJEQ&s";
            }
        }
    }
}
