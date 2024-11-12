using airport.Models;
using airport.Models.AirportInfoAPI.Response;
using Newtonsoft.Json;
using System.Web;

namespace airport.Helper
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly List<ISubscriptionKeyStrategy> _strategies;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.swedavia.se/");
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SubscriptionKeyAirportInfo.getKey());

            _strategies = new List<ISubscriptionKeyStrategy>
        {
            new AirportInfoSubscriptionKeyStrategy(),
            new FlightInfoSubscriptionKeyStrategy(),
            new WaitTimePublicSubscriptionKeyStrategy()
        };
        }

        public async Task<T> GetDataAsync<T>(string endpoint, Dictionary<string, object> queryParams = null)
        {
            var baseAddressString = _httpClient.BaseAddress.ToString();
            var uriBuilder = new UriBuilder(baseAddressString);
            uriBuilder.Path = endpoint;
            var query = HttpUtility.ParseQueryString(string.Empty);

            var strategy = _strategies.FirstOrDefault(s => s.CanHandle(endpoint));
            if (strategy != null)
            {
                _httpClient.DefaultRequestHeaders.Remove("Ocp-Apim-Subscription-Key");
                _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", strategy.GetKey());
            }

            if (queryParams != null && queryParams.Count > 0)
            {
                foreach (var param in queryParams)
                {
                    query[param.Key] = param.Value.ToString(); // Convert object to string for query parameters
                }
            }

            uriBuilder.Query = query.ToString();

            var response = await _httpClient.GetAsync(uriBuilder.Uri);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            return JsonConvert.DeserializeObject<T>(content);
        }

       


    }
}
