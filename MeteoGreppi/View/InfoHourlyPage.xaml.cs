using MeteoGreppi.ViewModel;
using MeteoGreppi.Model;

namespace MeteoGreppi.View;

public partial class InfoHourlyPage : ContentPage
{
    private Viewmodel viewModel;
    public InfoHourlyPage()
	{
		InitializeComponent();
        viewModel = ServiceLocator.ServiceProvider.GetService<Viewmodel>();
        BindingContext = viewModel;
    }

}