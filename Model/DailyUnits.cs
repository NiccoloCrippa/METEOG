using System.Text.Json.Serialization; 
namespace MeteoGreppi.Model{ 

    public class DailyUnits
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("weathercode")]
        public string Weathercode { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public string Temperature2mMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public string Temperature2mMin { get; set; }

        [JsonPropertyName("apparent_temperature_max")]
        public string ApparentTemperatureMax { get; set; }

        [JsonPropertyName("apparent_temperature_min")]
        public string ApparentTemperatureMin { get; set; }

        [JsonPropertyName("sunrise")]
        public string Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public string Sunset { get; set; }

        [JsonPropertyName("uv_index_max")]
        public string UvIndexMax { get; set; }

        [JsonPropertyName("precipitation_sum")]
        public string PrecipitationSum { get; set; }

        [JsonPropertyName("windspeed_10m_max")]
        public string Windspeed10mMax { get; set; }

        [JsonPropertyName("windgusts_10m_max")]
        public string Windgusts10mMax { get; set; }

        [JsonPropertyName("winddirection_10m_dominant")]
        public string Winddirection10mDominant { get; set; }
    }

}