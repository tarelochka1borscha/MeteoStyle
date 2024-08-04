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

        string messageText = "Комфортны ли для Вас рекомендации?";

        public bool CanChoice
        {
            get => canChoice;
            set
            {
                canChoice = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(CanChoice)));
            }
        }

        bool canChoice = true;

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

        int emojiSize = 25;

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
        }

        

        //private void ChoiceFeelings(object sender, EventArgs e)
        //{
        //    ButtonCold.FontSize = 25;
        //    ButtonNormal.FontSize = 25;
        //    ButtonWarm.FontSize = 25;
        //    CanChoice = false;
        //    Button selectedButton = (Button)sender;
        //    selectedButton.FontSize = 35;
        //    if (selectedButton != ButtonNormal)
        //    {
        //        LabelMessage.Text = "В следующий раз мы будем более внимательны :c";
        //    }
        //    else
        //    {
        //        LabelMessage.Text = "Рады Вам помочь <3";
        //    }
        //}
    }
}
