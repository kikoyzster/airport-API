using airport.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace airport.Helper
{
    public class ApiService2
    {
        private HttpClient _httpClient;
        private string baseAddressString = "https://api.swedavia.se/";

        public ApiService2() {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SubscriptionKeyAirportInfo.getKey());
        }

        public async Task<object> GetApiResponse<T>(string endpoint, Dictionary<string, string> queryParams = null)
        {
            Uri fullUri = BuildApiUri(endpoint, queryParams);

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(fullUri);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    try
                    {
                        
                        return JsonConvert.DeserializeObject<T>(responseBody);
                    }
                    catch (Newtonsoft.Json.JsonException)
                    {
                        return responseBody; // Return raw JSON string if deserialization fails
                    }
                }
                else
                {
                    // Handle unsuccessful response
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error accessing API: {ex.Message}");
                return null;
            }
        }

        private Uri BuildApiUri(string endpoint, Dictionary<string, string> queryParams)
        {
            UriBuilder builder = new UriBuilder(baseAddressString)
            {
                Path = endpoint
            };

            if (queryParams != null)
            {
                string query = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"));
                builder.Query = query;
            }

            return builder.Uri;
        }
    }
}
