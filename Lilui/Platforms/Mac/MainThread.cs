#if MACOS

using System.ComponentModel;

namespace Lilui.Platforms.Mac;

public class MainThread : IMainThread
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public MainThread()
    {
        NSApplication.Init();
    }

    public void Run()
    {
        NSApplication.Main(Environment.GetCommandLineArgs());
    }
}

#endif
