using airport.Models.AirportInfoAPI.Response;

namespace airport.Helper
{
    public interface IApiService
    {
        Task<T> GetDataAsync<T>(string endpoint, Dictionary<string, object> queryParams = null);
        
    }
}
