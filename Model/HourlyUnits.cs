using System.Text.Json.Serialization; 
namespace MeteoGreppi.Model{ 

    public class HourlyUnits
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public string Temperature2m { get; set; }

        [JsonPropertyName("relativehumidity_2m")]
        public string Relativehumidity2m { get; set; }

        [JsonPropertyName("apparent_temperature")]
        public string ApparentTemperature { get; set; }

        [JsonPropertyName("precipitation")]
        public string Precipitation { get; set; }

        [JsonPropertyName("weathercode")]
        public string Weathercode { get; set; }

        [JsonPropertyName("visibility")]
        public string Visibility { get; set; }

        [JsonPropertyName("windspeed_10m")]
        public string Windspeed10m { get; set; }

        [JsonPropertyName("winddirection_10m")]
        public string Winddirection10m { get; set; }

        [JsonPropertyName("windgusts_10m")]
        public string Windgusts10m { get; set; }

        [JsonPropertyName("uv_index")]
        public string UvIndex { get; set; }
    }

}