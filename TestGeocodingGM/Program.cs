using HttpProxyControl;
using System.IO;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Encodings.Web;
using System.Text.Json;


namespace TestGeocodingGM
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await OpenMeteoLocalizer();
            //await OpenWheatherMapLocalizer();
        }

        static async Task OpenWheatherMapLocalizer()
        {
            HttpClient client = HttpProxyHelper.CreateHttpClient(true);
            string baseAddress = "http://api.openweathermap.org/geo/1.0/";

            string city = "Monticello";
            string stateCode = string.Empty;
            string countryCode = "IT";
            string APIKey = "9a26276f876fdcf86679dfb853b80af2";
            string acceptedMediaType = "application/json";


            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(acceptedMediaType));

            FormattableString address = $"direct?q={city},{countryCode}&limit=10&appid={APIKey}";
            string addressURL = FormattableString.Invariant(address);
            HttpResponseMessage request = await client.GetAsync($"{addressURL}");

            if (request.IsSuccessStatusCode)
            {
                List<Location>? locations = await request.Content.ReadFromJsonAsync<List<Location>>();
                foreach (var loc in locations)
                {
                    Console.WriteLine($"Lat: {loc.Lat}, Long: {loc.Lon}");
                }
            }
            else
            {
                Console.WriteLine("C'è stato un problema");
            }
        }
        static async Task OpenMeteoLocalizer()
        {
            HttpClient client = HttpProxyHelper.CreateHttpClient(true);
            string baseAddress = "https://geocoding-api.open-meteo.com/v1/";
            string acceptedMediaType = "application/json";
            string city = "Berlino";

            FormattableString address = $"search?name={city}";
            string addressURL = FormattableString.Invariant(address);

            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(acceptedMediaType));

            HttpResponseMessage request = await client.GetAsync($"{addressURL}");

            if (request.IsSuccessStatusCode)
            {
                List<LocationOM>? locations = await request.Content.ReadFromJsonAsync<List<LocationOM>>();
                foreach (var loc in locations)
                {
                    Console.WriteLine($"Lat: {loc.Latitude}, Long: {loc.Longitude}");
                }
            }
            else
            {
                Console.WriteLine("C'è stato un problema");
            }
        }
        
    }
}