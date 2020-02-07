using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyorWeather.Models
{
    public class WeatherModel
    {

		private string _temp;
		private string _feelslike;
		private string _windspeed;
		private string _winddirections;
		private string _sunrise;
		private string _sunset;
		private string _city;
		private string _humidity;
		private string _time;

		public string Temperature
		{
			get { return _temp; }
			set
			{
				_temp = value;
			}
		}
		public string FeelsLike
		{
			get { return _feelslike; }
			set { _feelslike = value; }
		}
		public string WindSpeed
		{
			get { return _windspeed; }
			set { _windspeed = value; }
		}
		public string WindDirection
		{
			get { return _winddirections; }
			set { _winddirections = value; }
		}
		public string Sunrise
		{
			get { return _sunrise; }
			set { _sunrise = value;}
		}
		public string Sunset
		{
			get { return _sunset; }
			set { _sunset = value; }
		}
		public string City
		{
			get { return _city; }
			set { _city = value; }
		}
		public string Humidity
		{
			get { return _humidity; }
			set { _humidity = value; }
		}
		public string Time
		{
			get { return _time; }
			set
			{
				_time = value;
			}
		}
	}
}
