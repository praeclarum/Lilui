using Microsoft.Extensions.DependencyInjection;

#if MACOS
using Lilui.Platforms.Mac;
#elif WINDOWS
using Lilui.Platforms.Windows;
#else
using Lilui.Platforms.Web;
#endif

namespace Lilui;

public static class Services
{
    public static void AddLilui(this IServiceCollection services)
    {
        services.AddSingleton<IMainThread, MainThread>();
        services.AddTransient<IWindow, Window>();
    }
}
