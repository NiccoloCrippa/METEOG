//using AndroidX.Lifecycle;
using MeteoGreppi.Model;
using MeteoGreppi.ViewModel;
namespace MeteoGreppi;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

        var services = new ServiceCollection();
        services.AddSingleton<Viewmodel>();
        var serviceProvider = services.BuildServiceProvider();
        ServiceLocator.ServiceProvider = serviceProvider;
    }
    
}
