using Newtonsoft.Json;
using Sommerland.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Sommerland.Service
{
    // example of API call in the comment below
    // http://api.openweathermap.org/data/2.5/weather?appid=3654de113ecd4a2bf4e4144d9403491b&q=aalborg&units=metric
    public class OpenWeatherMap
    {
        private const string api = "http://api.openweathermap.org/data/2.5/weather?units=metric";
        public string City { get; set; }
        public string AppId { get; set; }
        public string Url { get
            {
                return  $"{api}&appid={AppId}&q={City}";
            }
        }

        private OpenWeather GetOpenWeather()
        {
            using(WebClient client = new WebClient())
            {
                string json = client.DownloadString(Url);
                OpenWeather weather = JsonConvert.DeserializeObject<OpenWeather>(json);
                return weather;
            }
        }
        public string GetWeatherIcon()
        {
                return $"http://openweathermap.org/img/w/{GetOpenWeather().Weather.FirstOrDefault().Icon}.png";
        }
        public string GetWeatherMain()
        {
                return GetOpenWeather().Weather.FirstOrDefault().Main;
        }
        public string GetWeatherDesc()
        {
                return GetOpenWeather().Weather.FirstOrDefault().Description;
        }
        public double GetTempature()
        {
                return GetOpenWeather().Main.Temp;
        }

    }
}
