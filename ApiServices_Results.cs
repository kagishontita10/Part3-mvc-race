using part3_mvc_consume.Models;
using Results = part3_mvc_consume.Models.Results;
namespace part3_mvc_consume.Services
{
    public class ApiServices_Results
    {

        private readonly HttpClient _httpClient;
        public ApiServices_Results(HttpClient http) { _httpClient = http; }
        public async Task<string> get_results(string userID)
        {
            HttpResponseMessage res = await _httpClient.GetAsync($"api/ResultsController/getResults?userID={userID}");
            return await res.Content.ReadAsStringAsync();
        }
        public async Task<string> store_result(string userID, Results r)
        {
            string url = $"api/ResultsController/addResult?userID={userID}&enrolmentID={r.enrolmentID}&finishTime={r.finishTime}&position={r.position}";
            HttpResponseMessage res = await _httpClient.PostAsync(url, null);
            return await res.Content.ReadAsStringAsync();
        }
    }
}


    

