using MeteoGreppi.Model;
using MeteoGreppi.ViewModel;

namespace MeteoGreppi.View;

public partial class ServicePage : ContentPage
{
    private Viewmodel viewModel;
    bool Vishourly = false;
	public ServicePage()
	{
       
        InitializeComponent();
        viewModel = ServiceLocator.ServiceProvider.GetService<Viewmodel>();
        BindingContext = viewModel;
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

    private void vis_Clicked(object sender, EventArgs e)
    {
        Vishourly = !Vishourly;
        if (Vishourly)
        {
            CollD.IsVisible = false;
            CollH.IsVisible = true;
        }
        else
        {
            CollD.IsVisible = true;
            CollH.IsVisible = false;
        }
    }
}