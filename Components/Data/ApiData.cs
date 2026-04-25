using Lims.Components.Model;
using LIMS.Model;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;


namespace Lims.Components.Data
{
   public class ApiData
    {
        private readonly HttpClient http;
        private readonly AppSettings appsettings;
        public ApiData(HttpClient _http, AppSettings _appsettings)
        {
            http = _http;
            appsettings = _appsettings;
            http.DefaultRequestHeaders.Add("X-Tenant-ID", appsettings.ClientId);
        }
        public async Task<T> GetObjectData<T>(string token, string endpoint) where T : new()
        {
            try
            {

                var request = new HttpRequestMessage(HttpMethod.Get, $"{appsettings.BaseUrl}{endpoint}");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await http.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var ret = JsonConvert.DeserializeObject<T>(content) ?? new T();
                    return ret;
                }

                return new T();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new T();
            }
        }
        public async Task<IList<T>> GetMasterList<T>(string token, string endpoint)
        {
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;


                var request = new HttpRequestMessage(HttpMethod.Get, $"{appsettings.BaseUrl}{endpoint}");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await http.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var ret = JsonConvert.DeserializeObject<IList<T>>(content) ?? new List<T>();
                    return ret;
                }

                return new List<T>();

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<T>();
            }
        }

        public async Task<string> PostData<T>(string token, string endpoint, T model)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(HttpMethod.Post, $"{appsettings.BaseUrl}{endpoint}")
                {
                    Content = content
                };
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await http.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent.Contains("success", StringComparison.OrdinalIgnoreCase)
                        ? "Success"
                        : responseContent;
                }

                var error = await response.Content.ReadAsStringAsync();
                return $"Error: {response.StatusCode} - {error}";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message.ToString();
            }
        }

        public async Task<HttpResponseMessage> SubmitRequestForm(RequestForm model, string? token)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

        // The endpoint for prenatal screening submission. A "Not Found" error indicates this URL might be incorrect.
        var request = new HttpRequestMessage(HttpMethod.Post, $"{appsettings.BaseUrl}PrenatalScreening")
                {
                    Content = content
                };

                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                return await http.SendAsync(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API call failed: {ex.Message}");
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError) { ReasonPhrase = ex.Message };
            }
        }

        public async Task<string> PostPreNatalResult(string token, PreNatalResultData model)
        {
            // This method uses the generic PostData method to save PreNatalResult.
            // The endpoint is assumed to be "PreNatalResult". You may need to adjust this based on your API controller.
            return await PostData(token, "PreNatalResult", model);
        }
    }


}
