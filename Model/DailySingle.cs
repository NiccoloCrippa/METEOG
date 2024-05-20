using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MeteoGreppi.Model
{
    public class DailySingle
    {
        public string Time { get; set; }
        public int Weathercode { get; set; }
        public double Temperature2mMax { get; set; }
        public double Temperature2mMin { get; set; }
        public double ApparentTemperatureMax { get; set; }
        public double ApparentTemperatureMin { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public double UvIndexMax { get; set; }
        public double PrecipitationSum { get; set; }
        public double Windspeed10mMax { get; set; }
        public double Windgusts10mMax { get; set; }
        public int Winddirection10mDominant { get; set; }
    }
}
