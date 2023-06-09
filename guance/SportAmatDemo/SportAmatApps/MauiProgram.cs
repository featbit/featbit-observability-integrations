using Microsoft.Maui.LifecycleEvents;

namespace SportAmatApps;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
            .ConfigureLifecycleEvents(events =>
            {
#if WINDOWS
                events.AddWindows(windows => windows
                       .OnActivated((window, args) => LogEvent(nameof(WindowsLifecycle.OnActivated)))
                       .OnClosed((window, args) => LogEvent(nameof(WindowsLifecycle.OnClosed)))
                       .OnLaunched((window, args) => LogEvent(nameof(WindowsLifecycle.OnLaunched)))
                       .OnLaunching((window, args) => LogEvent(nameof(WindowsLifecycle.OnLaunching)))
                       .OnVisibilityChanged((window, args) => LogEvent(nameof(WindowsLifecycle.OnVisibilityChanged)))
                       .OnPlatformMessage((window, args) =>
                       {
                           if (args.MessageId == Convert.ToUInt32("031A", 16))
                           {
                               // System theme has changed
                           }
                       }));
#endif
                static bool LogEvent(string eventName, string type = null)
                {
                    System.Diagnostics.Debug.WriteLine($"Lifecycle event: {eventName}{(type == null ? string.Empty : $" ({type})")}");
                    return true;
                }
            });

        return builder.Build();
    }
}
