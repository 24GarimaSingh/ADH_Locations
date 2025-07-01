using AFH_Locations_Project.Models;
using Microsoft.Extensions.Caching.Memory;
namespace AFHOfficeFeedApi.Services;

public class LocationService
{
    private readonly IMemoryCache _cache;
    private readonly HttpClient _httpClient;
    private const string ApiUrl = "https://www.afhwm.co.uk/api/v1/locations";

    public LocationService(IMemoryCache cache, HttpClient httpClient)
    {
        _cache = cache;
        _httpClient = httpClient;
    }

    public async Task<List<AFHOfficeFeedModel>> GetLocationsAsync()
    {
        const string cacheKey = "office_locations";

        if (_cache.TryGetValue(cacheKey, out List<AFHOfficeFeedModel> cachedLocations))
        {
            return cachedLocations;
        }

        var result = await _httpClient.GetFromJsonAsync<List<AFHOfficeFeedModel>>(ApiUrl);
        var locations = result?.Take(12).ToList() ?? new List<AFHOfficeFeedModel>();

       _cache.Set(cacheKey, locations, TimeSpan.FromMinutes(1));

        return locations;
    
    }
}
