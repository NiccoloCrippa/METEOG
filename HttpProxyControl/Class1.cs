using Microsoft.Win32;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace HttpProxyControl
{
    public class HttpProxyHelper
    {
        /// <summary>

        /// Effettua il setup del client Http con l'eventuale proxy (se presente)

        /// Richiede:

        /// 1) l'istallazione del pacchetto Microsoft.Win32.Registry tramite NuGet

        /// 2) using Microsoft.Win32;

        /// 3) using System.Runtime.InteropServices;

        /// 4) using System.Net;

        /// </summary>

        /// <param name="setProxy"></param>

        /// <returns>un oggetto HttpClient con eventuale proxy configurato</returns>

        public static HttpClient CreateHttpClient(bool setProxy)

        {

            if (setProxy)

            {

                Uri? proxy;

                //https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.defaultproxy?view=net-6.0

                //https://medium.com/@sddkal/net-core-interaction-with-registry-4d7fcabc7a6b

                //https://www.shellhacks.com/windows-show-proxy-settings-cmd-powershell/

                //https://stackoverflow.com/a/63884955

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))

                {

                    //ottengo lo user specific proxy che si ottiene con il comando:

                    //C:\> reg query "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings"

                    //per poter utilizzare Registry occorre:

                    //1) --> istallare il pacchetto Microsoft.Win32.Registry tramite NuGet

                    //2) --> using Microsoft.Win32;

                    //leggiamo lo user specific proxy direttamente dal registro di sistema di Windows

                    RegistryKey? internetSettings = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings");

                    //il proxy viene abilitato mediante il valore della chiave di registro ProxyEnable

                    int? proxyEnable = internetSettings?.GetValue("ProxyEnable") as int?;

                    //impostiamo proxy

                    proxy = (proxyEnable > 0 && internetSettings?.GetValue("ProxyServer") is string userProxy) ? new Uri(userProxy) : null;

                }

                else //se il sistema operativo è diverso da Windows procediamo con la determinazione del system wide proxy (se impostato)

                {

                    //questa è la procedura per ottenere il system proxy

                    Uri destinationUri = new("https://www.google.it");

                    //Ottiene il default proxy quando si prova a contattare la destinationUri

                    //Se il proxy non è impostato si ottiene null

                    //Uri proxy = HttpClient.DefaultProxy.GetProxy(destinationUri);

                    //Con il proxy calcolato in automatico si crea l'handler da passare all'oggetto HttpClient e

                    //funziona sia che il proxy sia configurato sia che non lo sia

                    proxy = HttpClient.DefaultProxy.GetProxy(destinationUri);

                }

                //con il proxy ottenuto con il codice precedente

                HttpClientHandler httpHandler = new()

                {

                    Proxy = new WebProxy(proxy, true),

                    UseProxy = true,

                    PreAuthenticate = false,

                    UseDefaultCredentials = false,

                };

                return new HttpClient(httpHandler);

            }

            else

            {

                return new HttpClient();

            }

        }

        /// <summary>

        /// Recupera il nome del file dall'url

        /// https://stackoverflow.com/a/40361205

        /// https://stackoverflow.com/questions/1105593/get-file-name-from-uri-string-in-c-sharp

        /// </summary>

        /// <param name="url"></param>

        /// <returns></returns>

        static string GetFileNameFromUrl(string url)

        {

            Uri SomeBaseUri = new Uri("http://canbeanything");

            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri uri))

            {

                uri = new Uri(SomeBaseUri, url);

            }

            //Path.GetFileName funziona se ha in input un URL assoluto

            return Path.GetFileName(uri.LocalPath);

        }

        /// <summary>

        /// Estrae il campo summary dal JSON restituito dall'Action API di Wikipedia

        /// </summary>

        /// <param name="wikiSummary">il summary in formato JSON</param>

        /// <returns>La stringa corrispondente al contenuto del campo extract, stringa vuota se non riesce a fare l'estrazione</returns>

        private static string ExtractSummaryFromJSON(string wikiSummary)

        {

            using JsonDocument document = JsonDocument.Parse(wikiSummary);

            JsonElement root = document.RootElement;

            JsonElement query = root.GetProperty("query");

            JsonElement pages = query.GetProperty("pages");

            //per prendere il primo elemento dentro pages, creo un enumeratore delle properties

            JsonElement.ObjectEnumerator enumerator = pages.EnumerateObject();

            //quando si crea un enumeratore su una collection, si deve farlo avanzare di una posizione per portarlo sul primo elemento della collection

            //il primo elemento corrisponde all'id della pagina all'interno dell'oggetto pages

            if (enumerator.MoveNext())

            {

                //accedo all'elemento

                JsonElement targetJsonElem = enumerator.Current.Value;

                if (targetJsonElem.TryGetProperty("extract", out JsonElement extract))

                {

                    return extract.GetString() ?? string.Empty;

                }

            }

            return string.Empty;

        }
    }
}