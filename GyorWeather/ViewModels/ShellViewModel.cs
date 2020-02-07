using Caliburn.Micro;
using GyorWeather.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Windows;

namespace GyorWeather.ViewModels
{
	public class ShellViewModel : Screen
	{
		private WeatherModel _weather = new WeatherModel();
		public WeatherModel Weather
		{
			get { return _weather; }
			set { _weather = value; }
		}
		// Konstruktor
		public ShellViewModel()
		{
			Update();	
		}
		// Adatok tárolása, frissítése
		public void Update()
		{
			var Object = GetWeather();
			if (!(Object is null))
			{
				try
				{
					Weather.Temperature = Math.Round((double)Object["main"]["temp"] - 273.15).ToString() + "°C";
					Weather.FeelsLike = Math.Round((double)Object["main"]["feels_like"] - 273.15).ToString() + "°C";
					Weather.Humidity = Math.Round((double)Object["main"]["humidity"]).ToString() + "%";
					Weather.Sunrise = UnixTime((int)Object["sys"]["sunrise"]);
					Weather.Sunset = UnixTime((int)Object["sys"]["sunset"]);
					Weather.WindSpeed = ((double)Object["wind"]["speed"] * 3.6).ToString() + " km/h";
					Weather.WindDirection = Direction((int)Object["wind"]["deg"]);
					Weather.City = Object["name"].ToString();
					DateTime dt = DateTime.Now;
					Weather.Time = dt.ToString("HH:mm:ss tt");
					NotifyOfPropertyChange(() => Weather);
				}
				catch (Exception)
				{
					MessageBox.Show("Nem sikerült az adatok eltárolása!");
					
				}
			}
		}
		// Adat lekérés API-val
		private JObject GetWeather() 
		{
			JObject Object;
			var client = new RestClient("http://api.openweathermap.org/data/2.5/weather");
			var request = new RestRequest(Method.GET);
			request.AddParameter("id", 6690440);
			request.AddParameter("appid", "a21017d2f65b7002114cca6406d749df");
			request.AddParameter("mode", "json");
			try
			{
				Object = JObject.Parse(client.Execute(request).Content);
				if (!(Object.ContainsKey("coord")))
				{
					throw new Exception();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Nem sikerült az adatok lekérése!");
				Object = null;
			}
			return Object;
		}
		// Szélirányt meghatározó method
		private string Direction(int _wd)
		{
			string _direction = "";
			switch (_wd) 
			{
				case int n when (n < 23 || n > 337): 
					_direction = "Északi";
					break;
				case int n when (n < 68):
					_direction = "Észak-Keleti";
					break;
				case int n when (n < 113):
					_direction = "Keleti";
					break;
				case int n when (n < 158):
					_direction = "Dél-Keleti";
					break;
				case int n when (n < 203):
					_direction = "Dél";
					break;
				case int n when (n < 248):
					_direction = "Dél-Nyugati";
					break;
				case int n when (n < 293):
					_direction = "Nyugati";
					break;
				case int n when (n < 338):
					_direction = "Észak-Nyugati";
					break;
			}
			return _direction; 
		}
		// Unix idő átváltó method
		private string UnixTime(int unixtime) 
		{
			var timeSpan = TimeSpan.FromSeconds(unixtime); 
			var localDateTime = new DateTime(timeSpan.Ticks).ToLocalTime();
			return localDateTime.ToString("HH:mm tt");
		}
	}
}