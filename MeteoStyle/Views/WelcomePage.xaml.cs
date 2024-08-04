using MeteoStyle.ViewModels;
using MeteoStyle.Views;

namespace MeteoStyle
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private async void GoToHomePage(object sender, EventArgs e)
        {
            int selectedType = 3;
            if (RBCold.IsChecked) selectedType = 1;
            if (RBWarm.IsChecked) selectedType = 2;
            await Navigation.PushAsync(new MainPage(EntryCity.Text, selectedType));
        }
    }

}
