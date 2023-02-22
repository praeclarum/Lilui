#if MACOS

using System.ComponentModel;

namespace Lilui.Platforms.Mac;

public class Window : IWindow
{
    readonly NSWindow window;

    public event PropertyChangedEventHandler? PropertyChanged;

    string title = "";
    public string Title {
        get => title;
        set {
            var v = value ?? "";
            if (title == v)
                return;
            title = v;
            window.Title = title;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
        }
    }

    public Window()
    {
        window = new NSWindow(
            new CGRect(0, 0, 640, 480),
            NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled,
            NSBackingStore.Buffered,
            false
        );
    }

    public void Show()
    {
        window.MakeKeyAndOrderFront(null);
    }
}

#endif
