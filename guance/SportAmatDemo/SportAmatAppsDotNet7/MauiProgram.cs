using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace SportAmatAppsDotNet7
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSentry(options =>
                {
                    // The DSN is the only required setting.
                    options.Dsn = "https://47068eb177dd41aca55de1f308c3767f@o4505261100236800.ingest.sentry.io/4505261101416448";

                    // Use debug mode if you want to see what the SDK is doing.
                    // Debug messages are written to stdout with Console.Writeline,
                    // and are viewable in your IDE's debug console or with 'adb logcat', etc.
                    // This option is not recommended when deploying your application.
                    options.Debug = true;

                    // Set TracesSampleRate to 1.0 to capture 100% of transactions for performance monitoring.
                    // We recommend adjusting this value in production.
                    options.TracesSampleRate = 1.0;

                    // Other Sentry options can be set here.
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
//                .ConfigureLifecycleEvents(events =>
//                {
//#if WINDOWS
//                    events.AddWindows(windows => windows
//                           .OnActivated((window, args) => LogEvent(nameof(WindowsLifecycle.OnActivated)))
//                           .OnClosed((window, args) => LogEvent(nameof(WindowsLifecycle.OnClosed)))
//                           .OnLaunched((window, args) => LogEvent(nameof(WindowsLifecycle.OnLaunched)))
//                           .OnLaunching((window, args) => LogEvent(nameof(WindowsLifecycle.OnLaunching)))
//                           .OnVisibilityChanged((window, args) => LogEvent(nameof(WindowsLifecycle.OnVisibilityChanged)))
//                           .OnPlatformMessage((window, args) =>
//                           {
//                               if (args.MessageId == Convert.ToUInt32("031A", 16))
//                               {
//                                   // System theme has changed
//                               }
//                           }));
//#endif
//                    static bool LogEvent(string eventName, string type = null)
//                    {
//                        System.Diagnostics.Debug.WriteLine($"Lifecycle event: {eventName}{(type == null ? string.Empty : $" ({type})")}");
//                        return true;
//                    }
//                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}