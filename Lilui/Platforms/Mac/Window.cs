using System.ComponentModel;

namespace Lilui.Platforms.Mac;

public class Window : IWindow
{
    NSWindow window;

    public event PropertyChangedEventHandler? PropertyChanged;

    public Window()
    {
        window = new NSWindow(
            new CGRect(0, 0, 640, 480),
            NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled,
            NSBackingStore.Buffered,
            false
        );
    }
}
