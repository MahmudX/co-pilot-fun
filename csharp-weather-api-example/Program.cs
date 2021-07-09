using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;

class Program
{
    // Replace these with your own values before running the sample.
    static string subscriptionKey = "ENTER_YOUR_SUBSCRIPTION_KEY";
    static void Main(string[] args)
    {
        // WriteLine to input city
        Console.WriteLine("Enter city name: ");
        // Create city field and read from console
        string city = Console.ReadLine();
        // Get the WeatherData from the input city
        WeatherData weather = GetWeatherData(city);
        // Print the temp from the weather data
        Console.WriteLine("The weather data for {0} is {1} with a high of {2} and a low of {3} but feels like {4}.",
        weather.name, weather.weather[0].description,
         weather.main.temp_max, weather.main.temp_min, weather.main.feels_like);
    }
    // Create GetWeatherData method
    // Return WeatherData object
    // Takes lat and lon as string parameters
    static WeatherData GetWeatherData(string lat, string lon)
    {
        // Create a new HttpClient
        HttpClient client = new HttpClient();
        // Create a new HttpeRequestMessage
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://api.openweathermap.org/data/2.5/weather?lat="
        + lat + "&lon=" + lon + "&unit=Metric&APPID=" + subscriptionKey);
        // Execute the request
        HttpResponseMessage response = client.SendAsync(request).Result;
        // Read the response as string
        string responseContent = response.Content.ReadAsStringAsync().Result;
        // Deserialize the string to object
        WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(responseContent);
        // Return the object
        return weatherData;
    }
    // Create GetWeatherData method
    // Return WeatherData object
    // Takes city as string parameter
    static WeatherData GetWeatherData(string city)
    {
        // Create a new HttpClient
        HttpClient client = new HttpClient();
        // Create a new HttpeRequestMessage
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&unit=Metric&APPID=" + subscriptionKey);
        // Execute the request
        HttpResponseMessage response = client.SendAsync(request).Result;
        // Read the response as string
        string responseContent = response.Content.ReadAsStringAsync().Result;
        // Deserialize the string to object
        WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(responseContent);
        // Return the object
        return weatherData;
    }

}

// Create class Weather
public class Main
{
    public double temp { get; set; }
    public double feels_like { get; set; }
    public double temp_min { get; set; }
    public double temp_max { get; set; }
    public int pressure { get; set; }
    public int humidity { get; set; }
    public int sea_level { get; set; }
    public int grnd_level { get; set; }
}
// Create class Weather
public class Weather
{
    public int id { get; set; }
    public string main { get; set; }
    public string description { get; set; }
    public string icon { get; set; }
}
// create class clouds
public class Clouds
{
    public int all { get; set; }
}
// Create class Wind
public class Wind
{
    public double speed { get; set; }
    public int deg { get; set; }
}
// Create class Rain
public class Rain
{
    public double _1h { get; set; }
}
// Create class Sys
public class Sys
{
    public string country { get; set; }
    public int sunrise { get; set; }
    public int sunset { get; set; }
}

// Create class Coord
public class Coord
{
    public double lat { get; set; }
    public double lon { get; set; }
}
// Create class WeatherData
public class WeatherData
{
    public Coord coord { get; set; }
    public List<Weather> weather { get; set; }
    public string @base { get; set; }
    public Main main { get; set; }
    public int visibility { get; set; }
    public Wind wind { get; set; }
    public Rain rain { get; set; }
    public Clouds clouds { get; set; }
    public int dt { get; set; }
    public Sys sys { get; set; }
    public int timezone { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public int cod { get; set; }
}


