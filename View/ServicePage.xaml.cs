using MeteoGreppi.Model;

namespace MeteoGreppi.View;

public partial class ServicePage : ContentPage
{
	public ServicePage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        await viewModel.SetDefaultPlace();
        barraDiRicerca.Text = viewModel.Place.Name;
        await viewModel.GetData();
    }

    private async void PreferencesButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SettingPage());
    }

    private async void barraDiRicerca_Completed(object sender, EventArgs e)
    {
        var city = barraDiRicerca.Text;
        var location = await viewModel.DirectGeocoding(city);

        viewModel.Place = new Place()
        {
            Name = city,
            Location = location
        };

        await viewModel.GetData();
    }

    private async void InfoButton_clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InfoHourlyPage());
    }
}