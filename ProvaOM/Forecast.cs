using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProvaOM
{
    public class Forecast
    {

        [JsonPropertyName("latitude")]

        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]

        public double Longitude { get; set; }

        [JsonPropertyName("generationtime_ms")]

        public double GenerationtimeMs { get; set; }

        [JsonPropertyName("utc_offset_seconds")]

        public int UtcOffsetSeconds { get; set; }

        [JsonPropertyName("timezone")]

        public string? Timezone { get; set; }

        [JsonPropertyName("timezone_abbreviation")]

        public string? TimezoneAbbreviation { get; set; }

        [JsonPropertyName("elevation")]

        public double Elevation { get; set; }

        [JsonPropertyName("current_weather")]

        public CurrentWeather? CurrentWeather { get; set; }

        [JsonPropertyName("hourly_units")]

        public HourlyUnits? HourlyUnits { get; set; }

        [JsonPropertyName("hourly")]

        public Hourly? Hourly { get; set; }

        [JsonPropertyName("daily_units")]

        public DailyUnits? DailyUnits { get; set; }

        [JsonPropertyName("daily")]

        public Daily? Daily { get; set; }

    }

    public class CurrentWeather

    {

        [JsonPropertyName("temperature")]

        public double Temperature { get; set; }

        [JsonPropertyName("windspeed")]

        public double Windspeed { get; set; }

        [JsonPropertyName("winddirection")]

        public double Winddirection { get; set; }

        [JsonPropertyName("weathercode")]

        public int Weathercode { get; set; }

        [JsonPropertyName("time")]

        public int Time { get; set; }

    }

    public class Daily

    {

        [JsonPropertyName("time")]

        public List<int>? Time { get; set; }

        [JsonPropertyName("weathercode")]

        public List<int>? Weathercode { get; set; }

        [JsonPropertyName("temperature_2m_max")]

        public List<double>? Temperature2mMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]

        public List<double>? Temperature2mMin { get; set; }

        [JsonPropertyName("apparent_temperature_max")]

        public List<double>? ApparentTemperatureMax { get; set; }

        [JsonPropertyName("apparent_temperature_min")]

        public List<double>? ApparentTemperatureMin { get; set; }

        [JsonPropertyName("sunrise")]

        public List<int>? Sunrise { get; set; }

        [JsonPropertyName("sunset")]

        public List<int>? Sunset { get; set; }

        [JsonPropertyName("uv_index_max")]

        public List<double>? UvIndexMax { get; set; }

        [JsonPropertyName("uv_index_clear_sky_max")]

        public List<double>? UvIndexClearSkyMax { get; set; }

        [JsonPropertyName("precipitation_sum")]

        public List<double>? PrecipitationSum { get; set; }

        [JsonPropertyName("rain_sum")]

        public List<double>? RainSum { get; set; }

        [JsonPropertyName("showers_sum")]

        public List<double>? ShowersSum { get; set; }

        [JsonPropertyName("snowfall_sum")]

        public List<double>? SnowfallSum { get; set; }

        [JsonPropertyName("precipitation_hours")]

        public List<double>? PrecipitationHours { get; set; }

        [JsonPropertyName("precipitation_probability_max")]

        public List<int>? PrecipitationProbabilityMax { get; set; }

        [JsonPropertyName("windspeed_10m_max")]

        public List<double>? Windspeed10mMax { get; set; }

        [JsonPropertyName("windgusts_10m_max")]

        public List<double>? Windgusts10mMax { get; set; }

        [JsonPropertyName("winddirection_10m_dominant")]

        public List<int>? Winddirection10mDominant { get; set; }

        [JsonPropertyName("shortwave_radiation_sum")]

        public List<double>? ShortwaveRadiationSum { get; set; }

        [JsonPropertyName("et0_fao_evapotranspiration")]

        public List<double>? Et0FaoEvapotranspiration { get; set; }

    }

    public class DailyUnits

    {

        [JsonPropertyName("time")]

        public string? Time { get; set; }

        [JsonPropertyName("weathercode")]

        public string? Weathercode { get; set; }

        [JsonPropertyName("temperature_2m_max")]

        public string? Temperature2mMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]

        public string? Temperature2mMin { get; set; }

        [JsonPropertyName("apparent_temperature_max")]

        public string? ApparentTemperatureMax { get; set; }

        [JsonPropertyName("apparent_temperature_min")]

        public string? ApparentTemperatureMin { get; set; }

        [JsonPropertyName("sunrise")]

        public string? Sunrise { get; set; }

        [JsonPropertyName("sunset")]

        public string? Sunset { get; set; }

        [JsonPropertyName("uv_index_max")]

        public string? UvIndexMax { get; set; }

        [JsonPropertyName("uv_index_clear_sky_max")]

        public string? UvIndexClearSkyMax { get; set; }

        [JsonPropertyName("precipitation_sum")]

        public string? PrecipitationSum { get; set; }

        [JsonPropertyName("rain_sum")]

        public string? RainSum { get; set; }

        [JsonPropertyName("showers_sum")]

        public string? ShowersSum { get; set; }

        [JsonPropertyName("snowfall_sum")]

        public string? SnowfallSum { get; set; }

        [JsonPropertyName("precipitation_hours")]

        public string? PrecipitationHours { get; set; }

        [JsonPropertyName("precipitation_probability_max")]

        public string? PrecipitationProbabilityMax { get; set; }

        [JsonPropertyName("windspeed_10m_max")]

        public string? Windspeed10mMax { get; set; }

        [JsonPropertyName("windgusts_10m_max")]

        public string? Windgusts10mMax { get; set; }

        [JsonPropertyName("winddirection_10m_dominant")]

        public string? Winddirection10mDominant { get; set; }

        [JsonPropertyName("shortwave_radiation_sum")]

        public string? ShortwaveRadiationSum { get; set; }

        [JsonPropertyName("et0_fao_evapotranspiration")]

        public string? Et0FaoEvapotranspiration { get; set; }

    }

    public class Hourly

    {

        [JsonPropertyName("time")]

        public List<int>? Time { get; set; }

        [JsonPropertyName("temperature_2m")]

        public List<double>? Temperature2m { get; set; }

        [JsonPropertyName("relativehumidity_2m")]

        public List<int>? Relativehumidity2m { get; set; }

        [JsonPropertyName("dewpoint_2m")]

        public List<double>? Dewpoint2m { get; set; }

        [JsonPropertyName("apparent_temperature")]

        public List<double>? ApparentTemperature { get; set; }

        [JsonPropertyName("precipitation_probability")]

        public List<int>? PrecipitationProbability { get; set; }

        [JsonPropertyName("precipitation")]

        public List<double>? Precipitation { get; set; }

        [JsonPropertyName("rain")]

        public List<double>? Rain { get; set; }

        [JsonPropertyName("showers")]

        public List<double>? Showers { get; set; }

        [JsonPropertyName("snowfall")]

        public List<double>? Snowfall { get; set; }

        [JsonPropertyName("snow_depth")]

        public List<double>? SnowDepth { get; set; }

        [JsonPropertyName("freezinglevel_height")]

        public List<double>? FreezinglevelHeight { get; set; }

        [JsonPropertyName("weathercode")]

        public List<int>? Weathercode { get; set; }

        [JsonPropertyName("pressure_msl")]

        public List<double>? PressureMsl { get; set; }

        [JsonPropertyName("surface_pressure")]

        public List<double>? SurfacePressure { get; set; }

        [JsonPropertyName("cloudcover")]

        public List<int>? Cloudcover { get; set; }

        [JsonPropertyName("cloudcover_low")]

        public List<int>? CloudcoverLow { get; set; }

        [JsonPropertyName("cloudcover_mid")]

        public List<int>? CloudcoverMid { get; set; }

        [JsonPropertyName("cloudcover_high")]

        public List<int>? CloudcoverHigh { get; set; }

        [JsonPropertyName("visibility")]

        public List<double>? Visibility { get; set; }

        [JsonPropertyName("evapotranspiration")]

        public List<double>? Evapotranspiration { get; set; }

        [JsonPropertyName("et0_fao_evapotranspiration")]

        public List<double>? Et0FaoEvapotranspiration { get; set; }

        [JsonPropertyName("vapor_pressure_deficit")]

        public List<double>? VaporPressureDeficit { get; set; }

        [JsonPropertyName("cape")]

        public List<double>? Cape { get; set; }

        [JsonPropertyName("windspeed_10m")]

        public List<double>? Windspeed10m { get; set; }

        [JsonPropertyName("windspeed_80m")]

        public List<double>? Windspeed80m { get; set; }

        [JsonPropertyName("windspeed_120m")]

        public List<double>? Windspeed120m { get; set; }

        [JsonPropertyName("windspeed_180m")]

        public List<double>? Windspeed180m { get; set; }

        [JsonPropertyName("winddirection_10m")]

        public List<int>? Winddirection10m { get; set; }

        [JsonPropertyName("winddirection_80m")]

        public List<int>? Winddirection80m { get; set; }

        [JsonPropertyName("winddirection_120m")]

        public List<int>? Winddirection120m { get; set; }

        [JsonPropertyName("winddirection_180m")]

        public List<int>? Winddirection180m { get; set; }

        [JsonPropertyName("windgusts_10m")]

        public List<double>? Windgusts10m { get; set; }

        [JsonPropertyName("temperature_80m")]

        public List<double>? Temperature80m { get; set; }

        [JsonPropertyName("temperature_120m")]

        public List<double>? Temperature120m { get; set; }

        [JsonPropertyName("temperature_180m")]

        public List<double>? Temperature180m { get; set; }

        [JsonPropertyName("soil_temperature_0cm")]

        public List<double>? SoilTemperature0cm { get; set; }

        [JsonPropertyName("soil_temperature_6cm")]

        public List<double>? SoilTemperature6cm { get; set; }

        [JsonPropertyName("soil_temperature_18cm")]

        public List<double>? SoilTemperature18cm { get; set; }

        [JsonPropertyName("soil_temperature_54cm")]

        public List<double>? SoilTemperature54cm { get; set; }

        [JsonPropertyName("soil_moisture_0_1cm")]

        public List<double>? SoilMoisture01cm { get; set; }

        [JsonPropertyName("soil_moisture_1_3cm")]

        public List<double>? SoilMoisture13cm { get; set; }

        [JsonPropertyName("soil_moisture_3_9cm")]

        public List<double>? SoilMoisture39cm { get; set; }

        [JsonPropertyName("soil_moisture_9_27cm")]

        public List<double>? SoilMoisture927cm { get; set; }

        [JsonPropertyName("soil_moisture_27_81cm")]

        public List<double>? SoilMoisture2781cm { get; set; }

    }

    public class HourlyUnits

    {

        [JsonPropertyName("time")]

        public string? Time { get; set; }

        [JsonPropertyName("temperature_2m")]

        public string? Temperature2m { get; set; }

        [JsonPropertyName("relativehumidity_2m")]

        public string? Relativehumidity2m { get; set; }

        [JsonPropertyName("dewpoint_2m")]

        public string? Dewpoint2m { get; set; }

        [JsonPropertyName("apparent_temperature")]

        public string? ApparentTemperature { get; set; }

        [JsonPropertyName("precipitation_probability")]

        public string? PrecipitationProbability { get; set; }

        [JsonPropertyName("precipitation")]

        public string? Precipitation { get; set; }

        [JsonPropertyName("rain")]

        public string? Rain { get; set; }

        [JsonPropertyName("showers")]

        public string? Showers { get; set; }

        [JsonPropertyName("snowfall")]

        public string? Snowfall { get; set; }

        [JsonPropertyName("snow_depth")]

        public string? SnowDepth { get; set; }

        [JsonPropertyName("freezinglevel_height")]

        public string? FreezinglevelHeight { get; set; }

        [JsonPropertyName("weathercode")]

        public string? Weathercode { get; set; }

        [JsonPropertyName("pressure_msl")]

        public string? PressureMsl { get; set; }

        [JsonPropertyName("surface_pressure")]

        public string? SurfacePressure { get; set; }

        [JsonPropertyName("cloudcover")]

        public string? Cloudcover { get; set; }

        [JsonPropertyName("cloudcover_low")]

        public string? CloudcoverLow { get; set; }

        [JsonPropertyName("cloudcover_mid")]

        public string? CloudcoverMid { get; set; }

        [JsonPropertyName("cloudcover_high")]

        public string? CloudcoverHigh { get; set; }

        [JsonPropertyName("visibility")]

        public string? Visibility { get; set; }

        [JsonPropertyName("evapotranspiration")]

        public string? Evapotranspiration { get; set; }

        [JsonPropertyName("et0_fao_evapotranspiration")]

        public string? Et0FaoEvapotranspiration { get; set; }

        [JsonPropertyName("vapor_pressure_deficit")]

        public string? VaporPressureDeficit { get; set; }

        [JsonPropertyName("cape")]

        public string? Cape { get; set; }

        [JsonPropertyName("windspeed_10m")]

        public string? Windspeed10m { get; set; }

        [JsonPropertyName("windspeed_80m")]

        public string? Windspeed80m { get; set; }

        [JsonPropertyName("windspeed_120m")]

        public string? Windspeed120m { get; set; }

        [JsonPropertyName("windspeed_180m")]

        public string? Windspeed180m { get; set; }

        [JsonPropertyName("winddirection_10m")]

        public string? Winddirection10m { get; set; }

        [JsonPropertyName("winddirection_80m")]

        public string? Winddirection80m { get; set; }

        [JsonPropertyName("winddirection_120m")]

        public string? Winddirection120m { get; set; }

        [JsonPropertyName("winddirection_180m")]

        public string? Winddirection180m { get; set; }

        [JsonPropertyName("windgusts_10m")]

        public string? Windgusts10m { get; set; }

        [JsonPropertyName("temperature_80m")]

        public string? Temperature80m { get; set; }

        [JsonPropertyName("temperature_120m")]

        public string? Temperature120m { get; set; }

        [JsonPropertyName("temperature_180m")]

        public string? Temperature180m { get; set; }

        [JsonPropertyName("soil_temperature_0cm")]

        public string? SoilTemperature0cm { get; set; }

        [JsonPropertyName("soil_temperature_6cm")]

        public string? SoilTemperature6cm { get; set; }

        [JsonPropertyName("soil_temperature_18cm")]

        public string? SoilTemperature18cm { get; set; }

        [JsonPropertyName("soil_temperature_54cm")]

        public string? SoilTemperature54cm { get; set; }

        [JsonPropertyName("soil_moisture_0_1cm")]

        public string? SoilMoisture01cm { get; set; }

        [JsonPropertyName("soil_moisture_1_3cm")]

        public string? SoilMoisture13cm { get; set; }

        [JsonPropertyName("soil_moisture_3_9cm")]

        public string? SoilMoisture39cm { get; set; }

        [JsonPropertyName("soil_moisture_9_27cm")]

        public string? SoilMoisture927cm { get; set; }

        [JsonPropertyName("soil_moisture_27_81cm")]

        public string? SoilMoisture2781cm { get; set; }

    }
}

