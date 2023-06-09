namespace SportAmatApps;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
    }

    写几个 Navigation 的案例，然后查查相关的内容

    再测试一下，在某个 ContentPage 中出现了 Exception Error时，Error所对应的信息是否包含相关的 Page, Window等

    学习Sentry的DataBinding，看看是不是能把相关的event都捕捉到

    protected override async void OnNavigated(ShellNavigatedEventArgs args)
    {
        base.OnNavigated(args);
        await DisplayAlert("Navigated", "Navigated to " + args.Current.Location.ToString(), "OK");
    }

    // Override OnNavigating
    protected override async void OnNavigating(ShellNavigatingEventArgs args)
    {
        base.OnNavigating(args);
        await DisplayAlert("Navigating", "Navigating to " + args.Target.Location.ToString(), "OK");
    }

    // OnNavigatedFrom
    protected override async void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
        //await DisplayAlert("NavigatedFrom", "NavigatedFrom " + args.Current.Location.ToString(), "OK");
    }

    // OnNavigatedTo
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        //await DisplayAlert("NavigatedTo", "NavigatedTo " + args.Current.Location.ToString(), "OK");
    }

    // Disappearing
    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        await DisplayAlert("Disappearing", "Disappearing", "OK");
    }

    //Appearing
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await DisplayAlert("Appearing", "Appearing", "OK");
    }
}
