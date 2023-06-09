using Microsoft.Maui.LifecycleEvents;
using System.Diagnostics;

namespace SportAmatApps;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();


	}

    protected override void OnResume()
    {
        base.OnResume();
    }

    protected override void OnStart()
    {
        base.OnStart();
    }

    protected override void OnSleep()
    {
        base.OnSleep();
    }
}
