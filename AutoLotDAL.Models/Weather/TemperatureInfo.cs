using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotDAL.Models.Weather
{
    public class TemperatureInfo
    {
        public float Temp { get; set; }
        public float Feels_like { get; set; }
        public float Humidity { get; set; }
    }
}
