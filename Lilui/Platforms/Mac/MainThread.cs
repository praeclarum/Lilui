#if MACOS

using System.ComponentModel;

namespace Lilui.Platforms.Mac;

public class MainThread : IMainThread
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public MainThread()
    {
        NSApplication.Init();
        var app = NSApplication.SharedApplication;
    }

    public void Run()
    {
        NSApplication.Main(Environment.GetCommandLineArgs());
    }

    
}

#endif
