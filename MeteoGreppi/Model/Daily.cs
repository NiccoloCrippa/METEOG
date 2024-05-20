using System.Text.Json.Serialization; 
using System.Collections.Generic; 
namespace MeteoGreppi.Model{ 

    public class Daily
    {
        [JsonPropertyName("time")]
        public List<string> Time { get; set; }

        [JsonPropertyName("weathercode")]
        public List<int> Weathercode { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public List<double> Temperature2mMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public List<double> Temperature2mMin { get; set; }

        [JsonPropertyName("apparent_temperature_max")]
        public List<double> ApparentTemperatureMax { get; set; }

        [JsonPropertyName("apparent_temperature_min")]
        public List<double> ApparentTemperatureMin { get; set; }

        [JsonPropertyName("sunrise")]
        public List<string> Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public List<string> Sunset { get; set; }

        [JsonPropertyName("uv_index_max")]
        public List<double> UvIndexMax { get; set; }

        [JsonPropertyName("precipitation_sum")]
        public List<double> PrecipitationSum { get; set; }

        [JsonPropertyName("windspeed_10m_max")]
        public List<double> Windspeed10mMax { get; set; }

        [JsonPropertyName("windgusts_10m_max")]
        public List<double> Windgusts10mMax { get; set; }

        [JsonPropertyName("winddirection_10m_dominant")]
        public List<int> Winddirection10mDominant { get; set; }
    }

}