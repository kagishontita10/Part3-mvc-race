using part3_mvc_consume.Models;

namespace part3_mvc_consume.Services
{
    public class ApiServices_eventRoute
    {

        private readonly HttpClient _httpClient;
        public ApiServices_eventRoute(HttpClient http) { _httpClient = http; }
        public async Task<string> get_routes()
        {
            HttpResponseMessage res = await _httpClient.GetAsync("api/eventRouteController/getRoute");
            return await res.Content.ReadAsStringAsync();
        }
        public async Task<string> store_route(string userID, eventRoute r)
        {
            string url = $"api/eventRouteController/addRoute?userID={userID}&eventID={r.eventID}&routeName={Uri.EscapeDataString(r.routeName)}&distance={r.distance}";
            HttpResponseMessage res = await _httpClient.PostAsync(url, null);
            return await res.Content.ReadAsStringAsync();
        }
    }
}

    

