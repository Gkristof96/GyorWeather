using Caliburn.Micro;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Windows;

namespace GyorWeather.ViewModels
{
	public class ShellViewModel : Screen
	{
		private string _temp; // hőmérséklet
		private string _feelslike; // hőérzet
		private string _windspeed; // szélsebesség
		private string _winddirections; // szélirány
		private string _sunrise; //napkelte
		private string _sunset; //napnyugta
		private string _city; //város
		private string _humidity; //páratartalom
		private string _ido; //aktuális idő

		public string Temperature
		{
			get { return _temp; }
			set
			{
				_temp = value;
				NotifyOfPropertyChange(() => Temperature);
			}
		}
		public string FeelsLike
		{
			get { return _feelslike; }
			set { _feelslike = value; NotifyOfPropertyChange(() => FeelsLike); }
		}
		public string WindSpeed
		{
			get { return _windspeed; }
			set { _windspeed = value; NotifyOfPropertyChange(() => WindSpeed); }
		}
		public string WindDir
		{
			get { return _winddirections; }
			set { _winddirections = value; NotifyOfPropertyChange(() => WindDir); }
		}
		public string Sunrise
		{
			get { return _sunrise; }
			set { _sunrise = value; NotifyOfPropertyChange(() => Sunrise); }
		}
		public string Sunset
		{
			get { return _sunset; }
			set { _sunset = value; NotifyOfPropertyChange(() => Sunset); }
		}
		public string City
		{
			get { return _city; }
			set { _city = value; NotifyOfPropertyChange(() => City); }
		}
		public string Humidity
		{
			get { return _humidity; }
			set { _humidity = value; NotifyOfPropertyChange(() => Humidity); }
		}
		public string Ido
		{
			get { return _ido; }
			set
			{
				_ido = value;
				NotifyOfPropertyChange(() => Ido);
			}
		}
		public ShellViewModel() // ShellViewModel konstruktora
		{
			var Object = GetWeather();

			try
			{
				Temperature = Math.Round((double)Object["main"]["temp"] - 273.15).ToString() + "°C"; //hőmérséklet kinyerése formázása
				FeelsLike = Math.Round((double)Object["main"]["feels_like"] - 273.15).ToString() + "°C";
				Humidity = Math.Round((double)Object["main"]["humidity"]).ToString() + "%";
				Sunrise = Time((int)Object["sys"]["sunrise"]);
				Sunset = Time((int)Object["sys"]["sunset"]);
				WindSpeed = ((double)Object["wind"]["speed"] * 3.6).ToString() + " km/h";
				WindDir = Direction((int)Object["wind"]["deg"]);
				City = Object["name"].ToString();
				DateTime dt = DateTime.Now;
				Ido = dt.ToString("HH:mm:ss tt");
			}
			catch (Exception)
			{
				MessageBox.Show("Nem sikerült az adatok lekérése");
			}
		}
		public void Fresh() // gobm metódusa
		{
			var Object = GetWeather();
			// probálkozás az adatok kinyerésére, ha nincsenek adatok hibát dob a program
			try
			{
				Temperature = Math.Round((double)Object["main"]["temp"] - 273.15).ToString() + "°C"; // hőmérséklet kiszámítása, az érték kelvinben van tárolva ezért ki kell vonunk 273.15-t
				FeelsLike = Math.Round((double)Object["main"]["feels_like"] - 273.15).ToString() + "°C";
				Humidity = Math.Round((double)Object["main"]["humidity"]).ToString() + "%";
				Sunrise = Time((int)Object["sys"]["sunrise"]); //time metódus adja vissza az időt a unix időből
				Sunset = Time((int)Object["sys"]["sunset"]);
				WindSpeed = ((double)Object["wind"]["speed"] * 3.6).ToString() + " km/h"; // szélesbesség megadása 3.6-al szórzunk hogy megkapjuk a km/h-ás értéket
				WindDir = Direction((int)Object["wind"]["deg"]); // szélirány meghatározása a Direction metódusal 
				City = Object["name"].ToString(); // város 
				DateTime dt = DateTime.Now; // aktuális idő
				Ido = dt.ToString("HH:mm:ss tt");
			}
			catch (Exception)
			{
				MessageBox.Show("Nem sikerült az adatok lekérése");
			}
		}
		public JObject GetWeather() // ez a metódus felel az adatok lekérésért, erre egy Open Weather API-t használ ami Id alapján azonosítja a várost
		{
			var client = new RestClient("http://api.openweathermap.org/data/2.5/weather"); // Rest kliens létrehozása
			var request = new RestRequest(Method.GET); // beállítja a http hívás típusát
			request.AddParameter("id", 6690440); // a város id hozzáfűzése 
			request.AddParameter("appid", "a21017d2f65b7002114cca6406d749df"); // APIkey hozzáfűzése 
			request.AddParameter("mode", "json"); // a várt adatok formátumának beállítása
			JObject Object = JObject.Parse(client.Execute(request).Content); // Végrehatja a Rest hívást és feldolgozza a választ

			return Object;
		}
		public string Direction(int _wd) // Ez a metódus felel érte hogy megtudjuk milyen irányból fúj a szél, paraméterként megkapja a szél irányát °fokban
		{
			string _direction = "";
			switch (_wd) // a kapott fok nagysága alapján eldönti melyik irányból fúj a szél
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
			return _direction; // a kapott irányt stringként adjuk vissza
		}
		public string Time(int unixtime) // Idő kinyerése Unix formátumból, a metódus paraméterként kapja meg a unixidőt
		{
			var timeSpan = TimeSpan.FromSeconds(unixtime); 
			var localDateTime = new DateTime(timeSpan.Ticks).ToLocalTime();
			return localDateTime.ToString("HH:mm tt");
		}
	}
}