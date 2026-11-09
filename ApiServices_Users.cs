using part3_mvc_consume.Models;

namespace part3_mvc_consume.Services
{
    public class ApiServices_Users
    {
        private readonly HttpClient _httpClient;
        public ApiServices_Users(HttpClient http) { _httpClient = http; }

        public async Task<string> store_user(Users user)
        {
            if (string.IsNullOrWhiteSpace(user.fullName) ||
                string.IsNullOrWhiteSpace(user.email) ||
                string.IsNullOrWhiteSpace(user.password) ||
                string.IsNullOrWhiteSpace(user.role))
            {
                return "Please fill in all fields - one is empty on MVC side";
            }

            try
            {
                string url = "api/UsersController/register"
                    + $"?fullName={Uri.EscapeDataString(user.fullName ?? "")}"
                    + $"&email={Uri.EscapeDataString(user.email ?? "")}"
                    + $"&password={Uri.EscapeDataString(user.password ?? "")}"
                    + $"&role={Uri.EscapeDataString(user.role ?? "")}";

                HttpResponseMessage res = await _httpClient.PostAsync(url, null);
                string result = await res.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception ex)
            {
                return "API ERROR: " + ex.Message;
            }
        }

        public async Task<string> login_user(string email, string password)
        {
            HttpResponseMessage res = await _httpClient.GetAsync($"api/UsersController/login?email={Uri.EscapeDataString(email)}&password={Uri.EscapeDataString(password)}");
            return await res.Content.ReadAsStringAsync();
        }

        public async Task<string> get_profile(string userID)
        {
            HttpResponseMessage res = await _httpClient.GetAsync($"api/UsersController/profile?userID={userID}");
            return await res.Content.ReadAsStringAsync();
        }

        public async Task<string> update_profile(string userID, string fullName, string email)
        {
            string url = $"api/UsersController/updateProfile?userID={userID}&fullName={Uri.EscapeDataString(fullName)}&email={Uri.EscapeDataString(email)}";
            HttpResponseMessage res = await _httpClient.PutAsync(url, null);
            return await res.Content.ReadAsStringAsync();
        }
    }
}
