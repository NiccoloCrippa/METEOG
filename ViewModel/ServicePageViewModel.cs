using System.Web;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Text.Json;
using MeteoGreppi.Model;
using System.Text;

namespace MeteoGreppi.ViewModel
{

    public partial class ServicePageViewModel : ObservableObject
    {

        private static HttpClient client = new HttpClient();

        [ObservableProperty]
        private Forecast forecast;

        [ObservableProperty]
        private List<HourlySingle> hourly;

        [ObservableProperty]
        private List<DailySingle> daily;

        [ObservableProperty]
        private Place place;

        public async Task GetData()
        {
            Forecast = await OMForecast(Place.Location.Latitude, Place.Location.Longitude);
        }

        async Task<Forecast> OMForecast(double? lat, double? lon)
        {
            string uglylat = lat.ToString();
            string uglylon = lon.ToString();

            string beautylat = uglylat.Replace(",", ".");
            string beautylon = uglylon.Replace(",", ".");

            Forecast forecast = null;
            FormattableString addressUrlFormattable = $"https://api.open-meteo.com/v1/forecast?latitude={beautylat}&longitude={beautylon}&hourly=temperature_2m,relativehumidity_2m,apparent_temperature,precipitation,weathercode,visibility,windspeed_10m,winddirection_10m,windgusts_10m,uv_index&daily=weathercode,temperature_2m_max,temperature_2m_min,apparent_temperature_max,apparent_temperature_min,sunrise,sunset,uv_index_max,precipitation_sum,windspeed_10m_max,windgusts_10m_max,winddirection_10m_dominant&current_weather=true&timezone=auto";
            string addressUrl = FormattableString.Invariant(addressUrlFormattable);
            var response = await client.GetAsync($"{addressUrl}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                forecast = JsonSerializer.Deserialize<Forecast>(content);

                var nuovoHourly = new List<HourlySingle>();
                for (int i = 0; i < forecast.Hourly.Time.Count; i++)
                {
                    nuovoHourly.Add(new HourlySingle()
                    {
                        Time = forecast.Hourly.Time[i],
                        Temperature2m = forecast.Hourly.Temperature2m[i],
                        Relativehumidity2m = forecast.Hourly.Relativehumidity2m[i],
                        ApparentTemperature = forecast.Hourly.ApparentTemperature[i],
                        Precipitation = forecast.Hourly.Precipitation[i],
                        Weathercode = forecast.Hourly.Weathercode[i],
                        Visibility = forecast.Hourly.Visibility[i],
                        Windspeed10m = forecast.Hourly.Windspeed10m[i],
                        Winddirection10m = forecast.Hourly.Winddirection10m[i],
                        Windgusts10m = forecast.Hourly.Windgusts10m[i],
                        UvIndex = forecast.Hourly.UvIndex[i],
                    });
                }

                Hourly = nuovoHourly;

                var nuovoDaily = new List<DailySingle>();
                for (int i = 0; i < forecast.Daily.Time.Count; i++)
                {
                    nuovoDaily.Add(new DailySingle()
                    {
                        Time = convertDate(forecast.Daily.Time[i]),
                        Weathercode = forecast.Daily.Weathercode[i],
                        Temperature2mMax = forecast.Daily.Temperature2mMax[i],
                        Temperature2mMin = forecast.Daily.Temperature2mMin[i],
                        ApparentTemperatureMax = forecast.Daily.ApparentTemperatureMax[i],
                        ApparentTemperatureMin = forecast.Daily.ApparentTemperatureMin[i],
                        Sunrise = forecast.Daily.Sunrise[i],
                        Sunset = forecast.Daily.Sunset[i],
                        UvIndexMax = forecast.Daily.UvIndexMax[i],
                        PrecipitationSum = forecast.Daily.PrecipitationSum[i],
                        Windspeed10mMax = forecast.Daily.Windspeed10mMax[i],
                        Windgusts10mMax = forecast.Daily.Windgusts10mMax[i],
                        Winddirection10mDominant = forecast.Daily.Winddirection10mDominant[i],
                    });
                }

                Daily = nuovoDaily;
                return forecast;
            }
            else
            {
                //Debug.WriteLine("Il recupero dei dati dal server non è riuscito");
                return forecast;
            }
        }

        public async Task<Location> GetCurrentLocation()
        {
            try
            {
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                Location location = await Geolocation.Default.GetLocationAsync(request);

                if (location != null)
                    return location;
            }

            catch (Exception ex)
            {
            }
            return null;
        }

        public async Task<Location> DirectGeocoding(string city)
        {
            IEnumerable<Location> locations = await Geocoding.Default.GetLocationsAsync(city);
            Location location = locations?.FirstOrDefault();
            return location;
        }

        public async Task<string> ReverseGeocoding(double lat, double lon)
        {
            IEnumerable<Placemark> placemarks = await Geocoding.Default.GetPlacemarksAsync(lat, lon);
            Placemark placemark = placemarks?.FirstOrDefault();
            return placemark.Locality;
        }

        public async Task SetDefaultPlace()
        {
            if (Preferences.Default.Get("geolocation", false))
            {
                var location = await GetCurrentLocation();
                var city = await ReverseGeocoding(location.Latitude, location.Longitude);

                Place = new Place()
                {
                    Location = location,
                    Name = city
                };
            }
            else
            {
                var city = Preferences.Default.Get("defaultCity", "Milano");
                var location = await DirectGeocoding(city);

                Place = new Place()
                {
                    Location = location,
                    Name = city
                };
            }
        }
        public static string convertDate(string date)
        {
            string[] array = date.Split('-');
            StringBuilder sb = new StringBuilder();
            sb.Append(array[2] + "/");
            sb.Append(array[1] + "/");
            sb.Append(array[0]);
            return sb.ToString();
        } 
    }
}

