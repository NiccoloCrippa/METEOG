using HttpProxyControl;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Web;
using System.Xml.Schema;

namespace ProvaOM
{
    public class Program
    {
        static readonly HttpClient client = HttpProxyHelper.CreateHttpClient(setProxy: true);

        //MAIN
        static async Task Main(string[] args)
        {
            await GeocodeByOpenMeteo("berlino");
        }

        static DateTime? UnixTimeStampToDateTime(double? unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            if (unixTimeStamp != null)
            {
                DateTime dateTime = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds((double)unixTimeStamp).ToLocalTime();
                return dateTime;
            }
            return null;
        }
        static async Task GeocodeByOpenMeteo(string? name, string? language = "it", int count = 1)
        {

            string? nameEncoded = HttpUtility.UrlEncode(name);
            string geocodingUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={nameEncoded}&count={count}&language={language}";
            try
            {
                HttpResponseMessage responseGeocoding = await client.GetAsync($"{geocodingUrl}");
                if (responseGeocoding.IsSuccessStatusCode)
                {
                    OpenMeteoGeocodingResult? geocodingResult = await responseGeocoding.Content.ReadFromJsonAsync<OpenMeteoGeocodingResult>();
                    if (geocodingResult != null && geocodingResult.Results?.Count > 0)
                    {
                        Console.WriteLine($"{geocodingResult.Results[0].Latitude},  {geocodingResult.Results[0].Longitude}");
                        //return (geocodingResult.Results[0].Latitude, geocodingResult.Results[0].Longitude);
                    }
                }
                //return null;
            }
            catch (Exception ex)
            {
                if (ex is HttpRequestException || ex is ArgumentException)
                {
                    Debug.WriteLine(ex.Message + "\nIl recupero dei dati dal server non è riuscito");
                }
            }
            //return null;
        }
        static string WMOCodesIntIT(int? code)
        {
            string result = code switch
            {
                0 => "cielo sereno",
                1 => "prevalentemente limpido",
                2 => "parzialmente nuvoloso",
                3 => "coperto",
                45 => "nebbia",
                48 => "nebbia con brina",
                51 => "pioggerellina di scarsa intensità",
                53 => "pioggerellina di moderata intensità",
                55 => "pioggerellina intensa",
                56 => "pioggerellina gelata di scarsa intensità",
                57 => "pioggerellina gelata intensa",
                61 => "pioggia di scarsa intensità",
                63 => "pioggia di moderata intensità",
                65 => "pioggia molto intensa",
                66 => "pioggia gelata di scarsa intensità",
                67 => "pioggia gelata intensa",
                71 => "nevicata di lieve entità",
                73 => "nevicata di media entità",
                75 => "nevicata intensa",
                77 => "granelli di neve",
                80 => "deboli rovesci di pioggia",
                81 => "moderati rovesci di pioggia",
                82 => "violenti rovesci di pioggia",
                85 => "leggeri rovesci di neve",
                86 => "pesanti rovesci di neve",
                95 => "temporale lieve o moderato",
                96 => "temporale con lieve grandine",
                99 => "temporale con forte grandine",
                _ => string.Empty,
            };
            return result;
        }
    }
}