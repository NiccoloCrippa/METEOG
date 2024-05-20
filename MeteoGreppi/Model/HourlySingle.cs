using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeteoGreppi.Model
{
    public class HourlySingle
    {
        public string Time { get; set; }
        public string Hour { get; set; }
        public double Temperature2m { get; set; }
        public int Relativehumidity2m { get; set; }
        public double ApparentTemperature { get; set; }
        public double Precipitation { get; set; }
        public int Weathercode { get; set; }
        public double Visibility { get; set; }
        public double Windspeed10m { get; set; }
        public int Winddirection10m { get; set; }
        public double Windgusts10m { get; set; }
        public double UvIndex { get; set; }
    }
}
