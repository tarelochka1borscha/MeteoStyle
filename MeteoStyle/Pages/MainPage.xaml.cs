using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MeteoStyle.Pages;

public partial class MainPage : ContentPage
{
	public bool CanChoice
	{
		get => canChoice;
		set
		{
            canChoice = value;
			OnPropertyChanged(nameof(CanChoice));
        }
	}

    bool canChoice = true;
	public MainPage(string currentCity, int selectedType)
	{
		InitializeComponent();
	}

    private void ChoiceFeelings(object sender, EventArgs e)
    {
		ButtonCold.FontSize = 25;
		ButtonNormal.FontSize = 25;
		ButtonWarm.FontSize = 25;
		CanChoice = false;
        Button selectedButton = (Button)sender;
		selectedButton.FontSize = 35;
		if (selectedButton!=ButtonNormal)
		{
			LabelMessage.Text = "В следующий раз мы будем более внимательны :c";
		}
		else
		{
			LabelMessage.Text = "Рады Вам помочь <3";
		}
    }
}