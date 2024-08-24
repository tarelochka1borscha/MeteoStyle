using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MeteoStyle.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string MessageText
        {
            get => messageText;
            set
            {
                messageText = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(MessageText)));
            }
        }

        private string messageText = "Комфортны ли для Вас рекомендации?";

        public string TemperatureText
        {
            get => temperatureText;
            set
            {
                temperatureText = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(TemperatureText)));
            }
        }

        private string temperatureText = string.Empty;

        public string WeatherText
        {
            get => weatherText;
            set
            {
                weatherText = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(WeatherText)));
            }
        }

        private string weatherText = string.Empty;

        public string ImageUrl
        {
            get => imageUrl;
            set
            {
                imageUrl = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(ImageUrl)));
            }
        }

        private string imageUrl = string.Empty;

        public bool CanChoice
        {
            get => canChoice;
            set
            {
                canChoice = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(CanChoice)));
            }
        }

        private bool canChoice = true;

        public int ColdEmojiSize
        {
            get => emojiSize;
            set
            {
                emojiSize = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(ColdEmojiSize)));
            }
        }

        public int ComfortEmojiSize
        {
            get => emojiSize;
            set
            {
                emojiSize = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(ComfortEmojiSize)));
            }
        }

        public int WarmEmojiSize
        {
            get => emojiSize;
            set
            {
                emojiSize = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(WarmEmojiSize)));
            }
        }

        private int emojiSize = 25;

        public ICommand ChoiceFeelingsClick { get; set; }

        public void ChoiceFeelings(object? arg)
        {
            CanChoice = false;
            switch (arg)
            {
                case "cold":
                    {
                        MessageText = "Просим извинения за неудобства. Теперь мы учитываем, что Вы воспримчивы к холоду.";
                        ColdEmojiSize = 35;
                        break;
                    }
                case "comfort":
                    {
                        MessageText = "Рады помочь <3";
                        ComfortEmojiSize = 35;
                        break;
                    }
                case "warm":
                    {
                        MessageText = "Просим извинения за неудобства. Теперь мы учитываем, что Вы воспримчивы к теплу.";
                        WarmEmojiSize = 35;
                        break;
                    }
            }
        }

        public MainPageViewModel(string currentCity, int selectedType)
        {
            ChoiceFeelingsClick = new Command(ChoiceFeelings);

            GetAndInsertWeatherData(currentCity.Trim());
        }

        private const string KEY = "7b4965a55f262b398bac64a46a2a3a0a";

        private void GetAndInsertWeatherData(string currentCity)
        {
            HttpClient client = new HttpClient();
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={currentCity}&appid={KEY}&units=metric&lang=ru";
            var data = JObject.Parse(client.GetStringAsync(url).Result);
            temperatureText = Convert.ToInt32(data["main"]["temp"]).ToString()+ "°C";
            string weather = data["weather"][0]["description"].ToString();
            weatherText = Char.ToUpper(weather[0]) + weather.Substring(1);
            imageUrl = "https://openweathermap.org/img/wn/" + data["weather"][0]["icon"].ToString() + "@2x.png";
        }
    }
}
