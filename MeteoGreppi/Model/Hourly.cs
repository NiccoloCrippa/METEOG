using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace MeteoGreppi.Model{ 

    public class Hourly
    {
        [JsonPropertyName("time")]
        public List<string> Time { get; set; }

        public List<string> Hour { get; set; }

        [JsonPropertyName("temperature_2m")]
        public List<double> Temperature2m { get; set; }

        [JsonPropertyName("relativehumidity_2m")]
        public List<int> Relativehumidity2m { get; set; }

        [JsonPropertyName("apparent_temperature")]
        public List<double> ApparentTemperature { get; set; }

        [JsonPropertyName("precipitation")]
        public List<double> Precipitation { get; set; }

        [JsonPropertyName("weathercode")]
        public List<int> Weathercode { get; set; }

        [JsonPropertyName("visibility")]
        public List<double> Visibility { get; set; }

        [JsonPropertyName("windspeed_10m")]
        public List<double> Windspeed10m { get; set; }

        [JsonPropertyName("winddirection_10m")]
        public List<int> Winddirection10m { get; set; }

        [JsonPropertyName("windgusts_10m")]
        public List<double> Windgusts10m { get; set; }

        [JsonPropertyName("uv_index")]
        public List<double> UvIndex { get; set; }
    }

}