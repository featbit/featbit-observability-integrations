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
�� Session First View �� Session Last View������� DataKit ���Լ�ȥ������𣿻��������� SDK ������أ������SDK�еļ����߼���ʲô�أ�

�� memory_avg��memory_max ��ָ���� MAUI �� Android �пɼ�⣬������ Windows �оͲ����Զ���⣬���߼������ݲ�׼ȷ��

https://docs.guance.com/real-user-monitoring/web/app-data-collection/
���� MAUI Windows �����ݼ��������� Web APPs �ļ�⡣

OnLaunched�¼�����Session��Create
OnClosed ��Ӧ���� windows �رգ����ܶ�Ӧ Session - Session�رտ��Զ�Ӧ�������̵�ֹͣ

### View

Window -> OnWindowCreated, OnClosed, OnResumed?, OnVisibilityChanged?

ContentPage

ContentView?

### Shell Navigation

Shell.Current, ���Ի��Window��ǰ�����Ϸ��� ContentPage�� 
ContentPage��navigation��������������ҳһ����URL��ַ�Ͳ�����

### Shell LifeCycle

https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/shell/lifecycle

### Resources

��Ϊ MAUI �� Resource �ĵ��ÿ������ڶ��߳�ͬʱ���еģ����뵱ǰView��һ����ֱ�ӹ�ϵ�������ڵ�ǰSession����һ����ֱ�ӹ�ϵ��

���� Resource �ĵ����޷�������ȥ�� Window, Page һһ���գ������ǿ��Խ���ǰ����״̬��View��Window��Resources�ĵ��ý���ƥ�䡣

�Լ������Ƿ��з���ȥ��ȡ��һ�� Page �� View �е���Դ��ȡ״������ͨ���Ա��߳�Id�ķ�ʽ��

����Ҳ����˵����ͬһ���̵߳� Resource ���ú͵�ǰ View ��û��ϵ...

���и����⣬Windowsǰ�˵ĵ�������Ƶ�ʿ���Զ����Web��������һЩ������������߿��ܶ���rgpc,websocket,socket�ȵ�ͨѶ������ÿ��ͨ�Ŷ���datakit�����������ܻ��½���

## ���� Sentry SDK

https://sentry.io/for/dotnet-maui/

https://github.com/getsentry/sentry-dotnet/blob/main/src/Sentry.Maui/Internal/MauiEventsBinder.cs
