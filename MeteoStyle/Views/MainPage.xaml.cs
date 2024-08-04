using MeteoStyle.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MeteoStyle.Views;

public partial class MainPage : ContentPage
{
	public MainPage(string currentCity, int selectedType)
	{
		InitializeComponent();
        MainPageViewModel viewModel = new MainPageViewModel(currentCity, selectedType);
        BindingContext = viewModel;
	}
}