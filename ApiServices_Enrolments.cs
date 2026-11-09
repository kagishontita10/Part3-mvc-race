using part3_mvc_consume.Models;
namespace part3_mvc_consume.Services
{
    public class ApiServices_Enrolments
    {
        private readonly HttpClient _httpClient;
        public ApiServices_Enrolments(HttpClient http) { _httpClient = http; }
        public async Task<string> get_enrolments(string userID) { HttpResponseMessage res = await _httpClient.GetAsync($"api/EnrolmentsController/getEnrolments?userID={userID}"); return await res.Content.ReadAsStringAsync(); }
        public async Task<string> store_enrolment(Enrolments e)
        {
            string url = $"api/EnrolmentsController/addEnrolment?userID={e.userID}&eventID={e.eventID}&categoryID={e.categoryID}&enrolmemtDate={e.enrolmemtDate}&status={e.status}";
            HttpResponseMessage res = await _httpClient.PostAsync(url, null); return await res.Content.ReadAsStringAsync();
        }
    }
}


    

