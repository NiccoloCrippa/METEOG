namespace MeteoGreppi.View;

public partial class SettingPage : ContentPage
{
	public SettingPage()
	{
		InitializeComponent();
        geolocationSwitch.IsToggled = Preferences.Default.Get("geolocation", false);
        defaultEntry.Text = Preferences.Default.Get("defaultCity", "Milano");
	}

    private void geolocationSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        Preferences.Default.Set("geolocation", e.Value);
    }

    private async void defaultEntry_Completed(object sender, EventArgs e)
    {
        Preferences.Default.Set("defaultCity", defaultEntry.Text);
        await DisplayAlert("PREFERENZE", "Hai cambiato correttamente la città predefinita", "OK");
    }
}