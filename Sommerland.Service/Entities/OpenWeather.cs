using System;
using System.Collections.Generic;
using System.Text;

namespace Sommerland.Service.Entities
{
    class OpenWeather
    {
        public List<Weather> Weather { get; set; }
        public Tempature Main { get; set; }
    }
}
