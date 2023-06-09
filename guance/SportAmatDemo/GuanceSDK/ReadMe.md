## App LifeCycle

https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/app-lifecycle

### Windows LifeCycle

- OnActivated, Invoked when the platform Activated event is raised, if the app isn't resuming.
- OnClosed, Invoked when the platform Closed event is raised.
- OnLaunched, Invoked by .NET MAUI's Application.OnLaunched override once the native window has been created and activated.
- OnLaunching, Invoked by .NET MAUI's Application.OnLaunched override before the native window has been created and activated.
- OnPlatformMessage, Invoked when .NET MAUI receives specific native Windows messages.
- OnPlatformWindowSubclassed, Invoked by .NET MAUI when the Win32 window is subclassed.
- OnResumed, Invoked when the platform Activated event is raised, if the app is resuming.
- OnVisibilityChanged, Invoked when the platform VisibilityChanged event is raised.
- OnWindowCreated, Invoked when the native window is created for the cross-platform Window.

### Session
像 Session First View 和 Session Last View，这个是 DataKit 中自己去计算的吗？还是我们在 SDK 传入的呢？这个在SDK中的计算逻辑是什么呢？

如 memory_avg，memory_max 的指标在 MAUI 的 Android 中可检测，但是在 Windows 中就不可自动监测，或者监测的数据不准确。

https://docs.guance.com/real-user-monitoring/web/app-data-collection/
可能 MAUI Windows 的数据监测更贴近于 Web APPs 的监测。

OnLaunched事件触发Session的Create
OnClosed 对应的是 windows 关闭，不能对应 Session - Session关闭可以对应整个进程的停止

### View

Window -> OnWindowCreated, OnClosed, OnResumed?, OnVisibilityChanged?

ContentPage

ContentView?

### Shell Navigation

Shell.Current, 可以获得Window当前在最上方的 ContentPage。 
ContentPage的navigation，甚至可以像网页一样加URL地址和参数。

### Shell LifeCycle

https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/shell/lifecycle

### Resources

因为 MAUI 的 Resource 的调用可能是在多线程同时进行的，且与当前View不一定有直接关系，甚至于当前Session都不一定有直接关系。

所以 Resource 的调用无法真正的去和 Window, Page 一一对照，但我们可以将当前激活状态的View和Window与Resources的调用进行匹配。

以及看看是否有方法去获取在一个 Page 或 View 中的资源调取状况，如通过对比线程Id的方式。

但你也不能说不在同一个线程的 Resource 调用和当前 View 就没关系...

还有个问题，Windows前端的调用请求频率可能远高于Web，尤其是一些金融软件，或者可能多用rgpc,websocket,socket等等通讯能力。每次通信都往datakit传，可能性能会下降。

## 参照 Sentry SDK

https://sentry.io/for/dotnet-maui/

https://github.com/getsentry/sentry-dotnet/blob/main/src/Sentry.Maui/Internal/MauiEventsBinder.cs
