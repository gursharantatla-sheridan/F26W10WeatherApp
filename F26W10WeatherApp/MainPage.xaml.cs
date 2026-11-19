namespace F26W10WeatherApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnGetWeatherBtnClicked(object sender, EventArgs e)
        {
            var loc = await Geolocation.Default.GetLocationAsync();
            var lat = loc.Latitude;
            var lon = loc.Longitude;

            string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&units=metric&appid=adee4d9d26685357054efd2f06359807";

            var weatherData = await WeatherProxy.GetWeatherAsync(url);

            CityLbl.Text = weatherData.name;
            TemperatureLbl.Text = weatherData.main.temp.ToString("F0") + "\u00B0C";
            ConditionsLbl.Text = weatherData.weather[0].description.ToUpper();

            string iconUrl = $"https://openweathermap.org/payload/api/media/file/{weatherData.weather[0].icon}.png";
            WeatherImg.Source = ImageSource.FromUri(new Uri(iconUrl));
        }
    }
}
