using part3_mvc_consume.Models;
namespace part3_mvc_consume.Services
{
    public class ApiServices_events
    {

        private readonly HttpClient _httpClient;
        public ApiServices_events(HttpClient http) { _httpClient = http; }
        public async Task<string> get_events() { HttpResponseMessage res = await _httpClient.GetAsync("api/EventsController/getEvents"); return await res.Content.ReadAsStringAsync(); }
        public async Task<string> store_event(string userID, Events e)
        {
            string url = "api/EventsController/addEvent" + $"?userID={userID}&EventName={Uri.EscapeDataString(e.EventName)}&description={Uri.EscapeDataString(e.description)}&EventDate={Uri.EscapeDataString(e.EventDate)}&location={Uri.EscapeDataString(e.location)}&eventType={Uri.EscapeDataString(e.eventType)}";
            HttpResponseMessage res = await _httpClient.PostAsync(url, null); return await res.Content.ReadAsStringAsync();
        }
    }
}
