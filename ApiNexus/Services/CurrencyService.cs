using System.Text.Json;
using ApiNexus.Data.Model;

namespace ApiNexus.Services
{
    public class CurrencyService
    {
        private readonly HttpClient _httpClient;
        public CurrencyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal?> ConvertCurrency(string from, string to, decimal amount)
        {
            var url = $"https://api.exchangerate.host/convert?from={from}&to={to}&amount={amount}&format=1&access_key=145f8c49efb4142f38eb73e2218812fb";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode) return null;

            using var stream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<ExchangeRateResponseModel>(stream);
            return result?.result;
        }
    }
}
